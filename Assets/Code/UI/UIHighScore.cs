using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GP2.Derri.States;

namespace GP2.Derri
{
    public class UIHighScore : MonoBehaviour
    {
        public void Restart()
        {
            GameStateManager.Instance.Go(StateType.InGame);
        }
        public void BackToMenu()
        {
            GameStateManager.Instance.Go(StateType.MainMenu);
        }

        public void Quit()
        {
            Application.Quit();
        }

    }

}