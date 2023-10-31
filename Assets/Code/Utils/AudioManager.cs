using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GP2.Derri.Config;
using static GP2.Derri.Config.AudioContainer;

namespace GP2.Derri
{
    public static  class AudioManager
    {
        private const string AudioContainerName = "AudioData";
        private static AudioContainer container;

        public static AudioContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = Resources.Load<AudioContainer>(AudioContainerName);
                }

                return container;
            }
        }


        public static bool PlayClip(AudioSource source, BackgroundMusic musicType)
        {
            AudioClip clip = Container.GetClipByType(musicType);
            if (clip != null && source != null)
            {
                source.PlayOneShot(clip);
                return true;
            }

            return false;
        }

        public static bool PlayOneShot(AudioSource source, SoundEffect effectType)
        {
            AudioClip clip = Container.GetClipByType(effectType);
            if (clip != null && source != null)
            {
                source.PlayOneShot(clip);
                return true;

            }

            return false;
        }


        public static float ToLinear(float db)
        {
            return Mathf.Clamp01(Mathf.Pow(10.0f, db / 20.0f));
        }

        public static float ToDB(float linear)
        {
            return linear <= 0 ? -80f : Mathf.Log10(linear) * 20.0f;
        }

    }
}
