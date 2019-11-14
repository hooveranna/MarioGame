using Microsoft.Xna.Framework.Graphics;
using Sprint_4.States;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Sprites
{
    public class BlockSpriteFactory
    {
        private Texture2D BrickBlock;
        private Texture2D QuestionBlock;
        private Texture2D UsedBlock;
        private Texture2D GroundBlock;
        private Texture2D DiamondBlock;
        private Texture2D PipeTopBlock;
        private Texture2D PipeLowerBlock;
        private Texture2D HiddenBlock;


        private Texture2D BrickBlockColored;
        private Texture2D GroundBlockColored;
        private Texture2D FlagPole;

        public BlockSpriteFactory(Texture2D brickBlock, Texture2D questionBlock, Texture2D usedBlock, Texture2D groundBlock, Texture2D diamondBlock, Texture2D pipeTopBlock, Texture2D pipeLowerBlock, Texture2D hiddenBlock, Texture2D brickBlockColored, Texture2D groundBlockColored, Texture2D flagPole)
        {
            BrickBlock = brickBlock;
            QuestionBlock = questionBlock;
            UsedBlock = usedBlock;
            GroundBlock = groundBlock;
            DiamondBlock = diamondBlock;
            PipeTopBlock = pipeTopBlock;
            PipeLowerBlock = pipeLowerBlock;
            HiddenBlock = hiddenBlock;

            BrickBlockColored = brickBlockColored;
            GroundBlockColored = groundBlockColored; 
            FlagPole = flagPole;

        }


        public Texture2D GetBlockSprite(string type)
        {
            Texture2D blockTexture = null;
            if (type.Equals("brick"))
            {
                blockTexture = BrickBlock;
            }
            else if (type.Equals("question"))
            {
                blockTexture = QuestionBlock;
            }
            else if (type.Equals("used"))
            {
                blockTexture = UsedBlock;
            }
            else if (type.Equals("ground"))
            {
                blockTexture = GroundBlock;
            }
            else if (type.Equals("diamond"))
            {
                blockTexture = DiamondBlock;
            }
            else if (type.Equals("pipetop"))
            {
                blockTexture = PipeTopBlock;
            }
            else if (type.Equals("pipelower"))
            {
                blockTexture = PipeLowerBlock;
            }
            else if (type.Equals("hidden"))
            {
                blockTexture = HiddenBlock;
            }
            else if (type.Equals("brickcolored"))
            {
                blockTexture = BrickBlockColored;
            }
            else if (type.Equals("groundcolored"))
            {
                blockTexture = GroundBlockColored;
            }
            else if (type.Equals("flag"))
            {
                blockTexture = FlagPole;
            }

            return blockTexture;
        }



    }
}
