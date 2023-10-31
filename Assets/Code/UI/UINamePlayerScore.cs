using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GP2.Derri.UI
{
    public class UINamePlayerScore : MonoBehaviour
    {
        [SerializeField]
        TMP_InputField inputField;

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void SetScoreWithName()
        {
            //inputField.text;
        }

    }
}
