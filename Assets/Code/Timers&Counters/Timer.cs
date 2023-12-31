using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GP2.Derri.States;

namespace GP2.Derri
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private StateType targetState;

        [SerializeField]
        private int levelIndex;

        public float timeValue = 90;
        public TextMeshProUGUI TimerText;

        private void Update()
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }

            DisplayTime(timeValue);
        }

        void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
                EndRound();
            }
            else if (timeToDisplay > 0)
            {
                timeToDisplay += 1;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);

            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        private void EndRound()
        {
            GameStateManager.Instance.Go(targetState);
        }
    }
}
