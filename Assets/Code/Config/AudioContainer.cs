using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri.Config
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "Data/Audio Container")]
    public class AudioContainer : ScriptableObject
    {
        public enum BackgroundMusic
        {
            None,
            JungleAmbience,
            RainAmbience,
            JungleAnimalSoundsBirds,
            JungleAnimalSoundsCrickets,
            MenuMusic,
            LevelMusic,

        }

        public enum SoundEffect
        {
            None,
            NavigationEffect,
            TongueStretch,
            Point,
            RoundDone,
            NewHighScore,
            NoNewHighScore1,
            NoNewHighScore2,

        }

        [Serializable]
        public class SoundItem1
        {
            public BackgroundMusic Type;
            public AudioClip Clip;
        }
        [SerializeField]
        private SoundItem1[] backgroundMusic;


        /// <summary>
        /// Returns the audio clip which matches the music type.
        /// </summary>
        /// <param name="effectType"></param>
        /// <returns>Correct clip if its in the backgroungMusics array. Null otherwise.</returns>
        public AudioClip GetClipByType(BackgroundMusic musicType)
        {
            foreach (SoundItem1 backgroungMusics in backgroundMusic)
            {
                if (backgroungMusics.Type == musicType)
                {
                    return backgroungMusics.Clip;
                }
            }

            return null;
        }



        [Serializable]
        public class SoundItem2
        {
            public SoundEffect Type;
            public AudioClip Clip;
        }
        [SerializeField]
        private SoundItem2[] soundEffects;

        /// <summary>
        /// Returns the audio clip which matches the effect type.
        /// </summary>
        /// <param name="effectType"></param>
        /// <returns>Correct clip if its in the soundEffect array. Null otherwise.</returns>
        public AudioClip GetClipByType(SoundEffect effectType)
        {
            foreach (SoundItem2 soundEffect in soundEffects)
            {
                if (soundEffect.Type == effectType)
                {
                    return soundEffect.Clip;
                }
            }

            return null;
        }
    }
}
