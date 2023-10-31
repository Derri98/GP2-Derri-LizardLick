using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GP2.Derri
{
    [RequireComponent(typeof(Toggle))]
    public class UIAudioToggle : MonoBehaviour
    {
        Toggle myToggle;

        void Start()
        {
            myToggle = GetComponent<Toggle>();

            if (AudioListener.volume == 0)
            {
                myToggle.isOn = true;
            }
        }

        public void ToggleAudioOnValueChange(bool audioIn)
        {
            if (audioIn)
            {
                AudioListener.volume = 0;
            }
            else
            {
                AudioListener.volume = 1;
            }
        }
    }
}
