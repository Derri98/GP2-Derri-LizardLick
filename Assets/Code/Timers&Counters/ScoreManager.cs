using GP2.Derri.Config;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GP2.Derri
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        public TextMeshProUGUI scoreNumber;
        public TextMeshProUGUI highscoreNumber;

        public AudioSource soundEffectAudio;

        int score = 0;
        int highscore = 0;

        private void Awake()
        {
            instance = this;

            soundEffectAudio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            //saving highscore as player prefs for now
            highscore = PlayerPrefs.GetInt("highscore", 0);

            scoreNumber.text = score.ToString();
            highscoreNumber.text = highscore.ToString();
        }

        public void AddPoint()
        {
            score += 1;

            scoreNumber.text = score.ToString();

            //saving highscore as player prefs for now
            if (highscore < score)
            {
                PlayerPrefs.SetInt("highscore", score);
            }

            if (soundEffectAudio != null)
            {
                AudioManager.PlayOneShot(soundEffectAudio, AudioContainer.SoundEffect.Point);

            }
        }
    }
}
