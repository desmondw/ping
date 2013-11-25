using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

using Ping.Global;

namespace Ping.Sound
{
    public class Audio
    {
        public enum SFX
        {
            //menu
            MenuMove,
            MenuSelect,
            MenuBack,

            //game
            BallSpawn,
            BallPaddleCollision,
            BallBallCollision,
            BallWallCollision,

            //used to measure enum size
            Count
        }

        public enum SFX_Silly_Male_BallBallCollision
        {
            Bam,
            Move,
            NoHomo,
            Sup,
            WatchIt,

            Count
        }

        public enum SFX_Silly_Male_BallPaddleCollision
        {
            Beep,
            Boop,
            Hater,
            Jerk,
            Ow1,
            Ow2,
            Ping,
            Sadist,
            StopIt,

            Count
        }

        public enum SFX_Silly_Male_BallSpawn
        {
            AmIABall,
            Balls,
            BigBalls,
            Boo,
            HereICome,
            Incomming,
            Karma,
            TheHell,

            Count
        }

        public enum SFX_Silly_Male_BallWallCollision
        {
            BrokenArrow,
            Finally,
            Later,
            Loser,
            Outtie,
            YouSuck,

            Count
        }

        //music
        private Song mus_Game;

        //sound effect lists
        private List<SoundEffect> Sounds;
        private List<SoundEffect> Sounds_Silly_Male_BallBallCollision;
        private List<SoundEffect> Sounds_Silly_Male_BallPaddleCollision;
        private List<SoundEffect> Sounds_Silly_Male_BallSpawn;
        private List<SoundEffect> Sounds_Silly_Male_BallWallCollision;

        //hack to get music to start playing only once (not none or repeatedly)
        private bool MusicStarted = false;

        public Audio(ContentManager content)
        {
            //music
            mus_Game = content.Load<Song>(Constants.FILEPATH_MUSIC + "CyberAdvance");
            MediaPlayer.Volume = 0.3f;

            Sounds = new List<SoundEffect>((int)SFX.Count);

            //menu
            Sounds.Insert((int)SFX.MenuMove, content.Load<SoundEffect>(Constants.FILEPATH_NORMAL_SOUND + "MenuMove"));
            Sounds.Insert((int)SFX.MenuSelect, content.Load<SoundEffect>(Constants.FILEPATH_NORMAL_SOUND + "MenuSelect"));
            Sounds.Insert((int)SFX.MenuBack, content.Load<SoundEffect>(Constants.FILEPATH_NORMAL_SOUND + "MenuBack"));

            //game
            Sounds.Insert((int)SFX.BallSpawn, content.Load<SoundEffect>(Constants.FILEPATH_NORMAL_SOUND + "BallSpawn"));
            Sounds.Insert((int)SFX.BallPaddleCollision, content.Load<SoundEffect>(Constants.FILEPATH_NORMAL_SOUND + "BallPaddleCollision"));
            Sounds.Insert((int)SFX.BallBallCollision, content.Load<SoundEffect>(Constants.FILEPATH_NORMAL_SOUND + "BallBallCollision"));
            Sounds.Insert((int)SFX.BallWallCollision, content.Load<SoundEffect>(Constants.FILEPATH_NORMAL_SOUND + "BallWallCollision"));

            //silly - male
            Sounds_Silly_Male_BallBallCollision = new List<SoundEffect>((int)SFX_Silly_Male_BallBallCollision.Count);
            Sounds_Silly_Male_BallBallCollision.Insert((int)SFX_Silly_Male_BallBallCollision.Bam, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_BALL + "male_bam"));
            Sounds_Silly_Male_BallBallCollision.Insert((int)SFX_Silly_Male_BallBallCollision.Move, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_BALL + "male_move"));
            Sounds_Silly_Male_BallBallCollision.Insert((int)SFX_Silly_Male_BallBallCollision.NoHomo, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_BALL + "male_nohomo"));
            Sounds_Silly_Male_BallBallCollision.Insert((int)SFX_Silly_Male_BallBallCollision.Sup, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_BALL + "male_sup"));
            Sounds_Silly_Male_BallBallCollision.Insert((int)SFX_Silly_Male_BallBallCollision.WatchIt, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_BALL + "male_watchit"));

            Sounds_Silly_Male_BallPaddleCollision = new List<SoundEffect>((int)SFX_Silly_Male_BallPaddleCollision.Count);
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Beep, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_beep"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Boop, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_boop"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Hater, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_hater"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Jerk, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_jerk"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Ow1, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_ow1"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Ow2, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_ow2"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Ping, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_ping"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.Sadist, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_sadist"));
            Sounds_Silly_Male_BallPaddleCollision.Insert((int)SFX_Silly_Male_BallPaddleCollision.StopIt, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_PADDLE + "male_stopit"));

            Sounds_Silly_Male_BallSpawn = new List<SoundEffect>((int)SFX_Silly_Male_BallSpawn.Count);
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.AmIABall, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_amiaball"));
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.Balls, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_balls"));
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.BigBalls, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_bigballs"));
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.Boo, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_boo"));
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.HereICome, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_hereicome"));
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.Incomming, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_incomming"));
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.Karma, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_karma"));
            Sounds_Silly_Male_BallSpawn.Insert((int)SFX_Silly_Male_BallSpawn.TheHell, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_SPAWN + "male_thehell"));

            Sounds_Silly_Male_BallWallCollision = new List<SoundEffect>((int)SFX_Silly_Male_BallWallCollision.Count);
            Sounds_Silly_Male_BallWallCollision.Insert((int)SFX_Silly_Male_BallWallCollision.BrokenArrow, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_WALL + "male_brokenarrow"));
            Sounds_Silly_Male_BallWallCollision.Insert((int)SFX_Silly_Male_BallWallCollision.Finally, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_WALL + "male_finally"));
            Sounds_Silly_Male_BallWallCollision.Insert((int)SFX_Silly_Male_BallWallCollision.Later, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_WALL + "male_later"));
            Sounds_Silly_Male_BallWallCollision.Insert((int)SFX_Silly_Male_BallWallCollision.Loser, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_WALL + "male_loser"));
            Sounds_Silly_Male_BallWallCollision.Insert((int)SFX_Silly_Male_BallWallCollision.Outtie, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_WALL + "male_outtie"));
            Sounds_Silly_Male_BallWallCollision.Insert((int)SFX_Silly_Male_BallWallCollision.YouSuck, content.Load<SoundEffect>(Constants.FILEPATH_SILLY_MALE_WALL + "male_yousuck"));
        }

        public bool PlaySound(SFX sound)
        {
            if (Settings.SoundOn)
            {

                Sounds[(int)sound].CreateInstance().Play();
                return true;
            }
            else
                return false;
        }

        public bool PlaySillyMaleBall()
        {
            if (Settings.SoundOn)
            {
                int index = new Random().Next((int)SFX_Silly_Male_BallBallCollision.Count - 1);
                Sounds_Silly_Male_BallBallCollision[index].CreateInstance().Play();
                return true;
            }
            else
                return false;
        }

        public bool PlaySillyMalePaddle()
        {
            if (Settings.SoundOn)
            {
                int index = new Random().Next((int)SFX_Silly_Male_BallPaddleCollision.Count - 1);
                Sounds_Silly_Male_BallPaddleCollision[index].CreateInstance().Play();
                return true;
            }
            else
                return false;
        }

        public bool PlaySillyMaleSpawn()
        {
            if (Settings.SoundOn)
            {
                int index = new Random().Next((int)SFX_Silly_Male_BallSpawn.Count - 1);
                Sounds_Silly_Male_BallSpawn[index].CreateInstance().Play();
                return true;
            }
            else
                return false;
        }

        public bool PlaySillyMaleWall()
        {
            if (Settings.SoundOn)
            {
                int index = new Random().Next((int)SFX_Silly_Male_BallWallCollision.Count - 1);
                Sounds_Silly_Male_BallWallCollision[index].CreateInstance().Play();
                return true;
            }
            else
                return false;
        }

        public void ToggleMusic()
        {
            if (Settings.MusicOn && MediaPlayer.State == MediaState.Stopped && !MusicStarted)
            {
                MediaPlayer.Play(mus_Game);
                MusicStarted = true;
            }
            else if (!Settings.MusicOn && MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Stop();
                MusicStarted = false;
            }
            else
                MusicStarted = false;
        }
    }
}
