using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_4.Collision;
using Sprint_4.Commands;
using Sprint_4.Content;
using Sprint_4.Controllers;
using Sprint_4.Factories;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.Sprites;
using Sprint_4.States;
using Sprint_4.Tools;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Sprint_4.GUI;
using Sprint_4.Observer_Pattern;
using Sprint_4.Checkpoint_System;
using System;

namespace Sprint_4
{
    //  Hello friends it is working
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteMaster spriteMaster;
        IController keyboardController;
        IController keyboardController2;
        IController gamePadController;
        SpriteFont font;
        CollisionGrid collisionGrid;
        Vector2 checkpointCoords = new Vector2(-1, -1);
        public bool Paused { get; set; }
        private bool gameIsOver = false;
        private bool hasWon = false;
        HUD hud;
        public Texture2D gameOverSprite { get; set; }
        public Texture2D winSprite { get; set; }
        public Soundboard soundboard { get; set; }
        //Camera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
         
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Paused = false;
            //Initialize each argument before sending it to contentloader
            //Controller initialization
            keyboardController = new KeyboardController();
            keyboardController2 = new KeyboardController();
            gamePadController = new GamePadController();

            keyboardController2.AddCommand((char)Keys.P, new PauseUnpauseGameCommand(this));
            keyboardController2.AddCommand((char)Keys.Q, new QuitCommand(this));
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteMaster = new SpriteMaster(new SpriteBatch(GraphicsDevice), new SpriteBatch(GraphicsDevice));
            //Collision initialization
            collisionGrid = new CollisionGrid();
            //Load font
            font = Content.Load<SpriteFont>("Font");
            //load hud
            hud = new HUD(GraphicsDevice, font);

            //New Contentloader method should make Game1 easier to follow.
            ContentLoader contentLoader = new ContentLoader(Content,GraphicsDevice, this, graphics, spriteMaster, keyboardController, gamePadController, collisionGrid, hud);
            contentLoader.LoadGameContents(checkpointCoords);
            //this.camera = contentLoader.GetCamera();
            this.spriteMaster = contentLoader.GetSpriteMaster();
        }

        public void ResetGame()
        {
            if (hud.Lives > 0)
            {
                spriteBatch.Dispose();
                spriteMaster.Dispose();
                collisionGrid = null;

                keyboardController = new KeyboardController();
                gamePadController = new GamePadController();

                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
                spriteMaster = new SpriteMaster(new SpriteBatch(GraphicsDevice), new SpriteBatch(GraphicsDevice));
                //Collision initialization
                collisionGrid = new CollisionGrid();

                //New Contentloader method should make Game1 easier to follow.
                ContentLoader contentLoader = new ContentLoader(Content, GraphicsDevice, this, graphics, spriteMaster, keyboardController, gamePadController, collisionGrid, hud);
                contentLoader.LoadGameContents(this.checkpointCoords, hud.Points, hud.Coins, hud.Lives);
                //this.camera = contentLoader.GetCamera();
                this.spriteMaster = contentLoader.GetSpriteMaster();
            }
            else
            {
                gameIsOver = true;
            }

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            keyboardController2.Update();
            //Debug.WriteLine("Update loop in Game1 is being run");
            //Poll keyboard and gamepad
            if (!(Paused || gameIsOver || hasWon))
            {
                keyboardController.Update();
                gamePadController.Update();

                //Update sprite positions + animations
                spriteMaster.Update(gameTime);

                //handle collisions
                collisionGrid.Update();

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (!gameIsOver && !hasWon)
            {
                GraphicsDevice.Clear(Color.Black);
                //Debug.WriteLine("Draw loop in Game1 is being run");
                //Use spriteMaster to abstract away sprite drawing logic
                spriteMaster.Begin();
                spriteBatch.Begin();
                spriteMaster.Draw();
                //collisionGrid.Draw();
                //Draw legend
                spriteBatch.DrawString(font, "G Toggles Gravity for Mario.", new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(font, "Z Teleports Mario to secret room.", new Vector2(0, 20), Color.White);
                spriteBatch.DrawString(font, "T Teleports Mario to Entity Testing room.", new Vector2(0, 40), Color.White);
                base.Draw(gameTime);
                spriteMaster.End();
                spriteBatch.End();
                hud.Draw();
            }
            else if(gameIsOver)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(gameOverSprite, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(winSprite, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                spriteBatch.End();
            }
        }

        public void OnCheckpointReached(object source, CheckpointEventArgs args)
        {
            this.checkpointCoords = args.Coordinates;
            Checkpoint obj = (Checkpoint)source;
            obj.CheckpointReached -= OnCheckpointReached;
        }

        public void OnMarioDeath(object source, EventArgs args)
        {
            ResetGame();
        }

        public void OnWin(object source, EventArgs args)
        {
            hasWon = true;
        }

        
    }
}
