using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

namespace GP2.Derri.UI
{
    public class UIVolumeControl : MonoBehaviour
    {

        private AudioMixer mixer;
        private Slider slider;
        private string parameterName;

        [SerializeField]
        private TMP_Text volumeText;

        [SerializeField]
        Toggle audioToggle;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
        }

        private void OnDestroy()
        {
            if (slider != null)
            {
                slider.onValueChanged.RemoveListener(OnSliderChanged);
            }
        }

        public void Setup(AudioMixer mixer, string parameterName)
        {
            this.mixer = mixer;
            this.parameterName = parameterName;

            if (this.mixer.GetFloat(this.parameterName, out float decibel))
            {
                float linear = AudioManager.ToLinear(decibel);

                SetVolume(linear);
            }

            slider.onValueChanged.AddListener(OnSliderChanged);

        }

        public void Save()
        {
            mixer.SetFloat(this.parameterName, AudioManager.ToDB(slider.value));
        }

        private void OnSliderChanged(float sliderValue)
        {
            volumeText.text = Mathf.RoundToInt(sliderValue * 100).ToString();
        }

        private void SetVolume(float linear)
        {
            slider.value = linear;
            volumeText.text = Mathf.RoundToInt(linear * 100).ToString();
        }
    }
}
