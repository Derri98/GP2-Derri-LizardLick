using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GP2.Derri.States;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace GP2.Derri.UI
{
    public class UIOptions : MonoBehaviour
    {
        [SerializeField]
        private UIVolumeControl musicVolume;

        [SerializeField]
        private UIVolumeControl sfxVolume;

        [SerializeField]
        private AudioMixer mixer;

        [SerializeField]
        private string backgroundVolumeName;

        [SerializeField]
        private string sfxVolumeName;

        private void Start()
        {
            musicVolume.Setup(mixer, backgroundVolumeName);
            sfxVolume.Setup(mixer, sfxVolumeName);
        }

        public void Save()
        {
            Debug.Log("Save options");

            musicVolume.Save();
            sfxVolume.Save();
        }

        public void Close()
        {
            GameStateManager.Instance.GoBack();
        }

        public void ExitToMenu()
        {
            GameStateManager.Instance.Go(StateType.MainMenu);
        }
    }
}
