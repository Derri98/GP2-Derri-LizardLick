using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GP2.Derri.States;

namespace GP2.Derri.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            GameStateManager.Instance.Go(StateType.InGame, levelIndex: 1);
        }

        public void OpenOptions()
        {
            GameStateManager.Instance.Go(StateType.Options);
        }

        public void OpenHighScore()
        {
            GameStateManager.Instance.Go(StateType.HighScore);
        }


        public void Quit()
        {
            //Exits the game.
            //Wont do anything in the editor.
            Application.Quit();
        }
    }
}
