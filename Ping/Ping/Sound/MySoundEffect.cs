using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Ping.Sound
{
    public class MySoundEffect
    {
        public SoundEffect SoundEffect;
        public SoundEffectInstance SoundEffectInstance;
        public string Name;

        public MySoundEffect(SoundEffect soundEffect, string name)
        {
            SoundEffect = soundEffect;
            Name = name;

            SoundEffectInstance = SoundEffect.CreateInstance();
        }
    }
}
