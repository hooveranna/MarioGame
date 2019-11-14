using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Sprint_4.Collision;
using Sprint_4.Commands;
using Sprint_4.Controllers;
using Sprint_4.Factories;
using Sprint_4.GUI;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.Sprites;
using Sprint_4.States;
using Sprint_4.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Sprint_4.Checkpoint_System;
using Sprint_4.Observer_Pattern;

namespace Sprint_4.Tools
{
    public class Soundboard
    {
        public SoundEffect[] sounds { get; set; }
        public Song[] songs { get; set; }
        public ContentManager Content { get; set; }

        public Soundboard(ContentManager content)
        {
            this.Content = content;
            sounds = new SoundEffect[19];
            sounds[0] = Content.Load<SoundEffect>("smb_1-up");
            sounds[1] = Content.Load<SoundEffect>("smb_breakblock");
            sounds[2] = Content.Load<SoundEffect>("smb_bump");
            sounds[3] = Content.Load<SoundEffect>("smb_coin");
            sounds[4] = Content.Load<SoundEffect>("smb_fireball");
            sounds[5] = Content.Load<SoundEffect>("smb_flagpole");
            sounds[6] = Content.Load<SoundEffect>("smb_gameover");
            sounds[7] = Content.Load<SoundEffect>("smb_jump-small");
            sounds[8] = Content.Load<SoundEffect>("smb_jump-super");
            sounds[9] = Content.Load<SoundEffect>("smb_kick");
            sounds[10] = Content.Load<SoundEffect>("smb_mariodie");
            sounds[11] = Content.Load<SoundEffect>("smb_pause");
            sounds[12] = Content.Load<SoundEffect>("smb_pipe");
            sounds[13] = Content.Load<SoundEffect>("smb_powerup");
            sounds[14] = Content.Load<SoundEffect>("smb_powerup_appears");
            sounds[15] = Content.Load<SoundEffect>("smb_stage_clear");
            sounds[16] = Content.Load<SoundEffect>("smb_stomp");
            sounds[17] = Content.Load<SoundEffect>("smb_warning");
            sounds[18] = Content.Load<SoundEffect>("smb_world_clear");

            songs = new Song[6];
            songs[0] = Content.Load<Song>("01-main-theme-overworld");
            songs[1] = Content.Load<Song>("05-starman");
            songs[2] = Content.Load<Song>("17-hurry-starman-");
            songs[3] = Content.Load<Song>("18-hurry-overworld-");
            songs[4] = Content.Load<Song>("02-underworld");
            songs[5] = Content.Load<Song>("14-hurry-underground-");
        }

        public void playOverworld()
        {
            MediaPlayer.Play(songs[0]);
        }

        public void playStar()
        {
            MediaPlayer.Play(songs[1]);
        }

        public void playHurryStar()
        {
            MediaPlayer.Play(songs[2]);
        }

        public void playHurryOverworld()
        {
            MediaPlayer.Play(songs[3]);
        }

        public void playUnderground()
        {
            MediaPlayer.Play(songs[4]);
        }

        public void playHurryUnderground()
        {
            MediaPlayer.Play(songs[5]);
        }

        public void play1Up()
        {
            sounds[0].Play();
        }

        public void playBreakBlock()
        {
            sounds[1].Play();
        }

        public void playBump()
        {
            sounds[2].Play();
        }

        public void playCoinCollect()
        {
            sounds[3].Play();
        }

        public void playFireball()
        {
            sounds[4].Play();
        }

        public void playFlagpole()
        {
            sounds[5].Play();
        }

        public void playGameOver()
        {
            sounds[6].Play();
        }

        public void playSmallJump()
        {
            sounds[7].Play();
        }

        public void playSuperJump()
        {
            sounds[8].Play();
        }

        public void playKickShell()
        {
            sounds[9].Play();
        }

        public void playMarioDie()
        {
            sounds[10].Play();
        }

        public void playPause()
        {
            sounds[11].Play();
        }

        public void playPipeEnter()
        {
            sounds[12].Play();
        }

        public void playPowerUp()
        {
            sounds[13].Play();
        }

        public void playPowerUpAppear()
        {
            sounds[14].Play();
        }

        public void playStageClear()
        {
            sounds[15].Play();
        }

        public void playEnemyDeath()
        {
            sounds[16].Play();
        }

        public void playWarning()
        {
            sounds[17].Play();
        }

        public void playWorldClear()
        {
            sounds[18].Play();
        }

        public void OnItemCollected(object source, ItemEventArgs args)
        {
            if(args.Item is CoinModel)
            {
                playCoinCollect();
            }else if(args.Item is GreenMushroomModel)
            {
                play1Up();
            }else if(args.Item is RedMushroomModel || args.Item is FireFlowerModel)
            {
                playPowerUp();
            }
        }

        public void OnBump(object source, BlockEventArgs args)
        {
            if(args.Model is BrickBlockWithItemModel)
            {
                playCoinCollect();
            }
            else if(args.Model is BrickBlockModel)
            {
                playBump();
            }else if(args.Model is QuestionBlockModel)
            {
                if(((QuestionBlockModel)args.Model).ItemModel is CoinModel)
                {
                    playCoinCollect();
                }
                else
                {
                    playPowerUpAppear();
                }
            }
        }

        public void OnJump(object source, EventArgs args)
        {
            if(((MarioModel)source).CurrentPowerupState is MarioStandardState)
            {
                playSmallJump();
            }
            else
            {
                playSuperJump();
            }
        }

        public void MarioDeath(object source, EventArgs args)
        {
            playMarioDie();
        }
    }
}
