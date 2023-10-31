using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GP2.Derri.States
{
    //Controls the games global state.
    public class GameStateManager : MonoBehaviour
    {
        private static GameStateManager instance;

        public static GameStateManager Instance
        {
            get
            {
                //Lazy loading, the instance is created the first time its needed.
                if (instance == null)
                {
                    GameStateManager prefab = Resources.Load<GameStateManager>(typeof(GameStateManager).Name);

                    instance = Instantiate(prefab);
                }

                return instance;
            }
        }

        private List<GameStateBase> states = new List<GameStateBase>();

        public GameStateBase CurrentState
        {
            get;
            private set;
        }

        public GameStateBase PreviousState
        {
            get;
            private set;
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.LogWarning($"Multiple {typeof(GameStateManager).Name} instances detected!" +
                    $"\n Destroying excess ones.");

                Destroy(this);
                return;
            }

            DontDestroyOnLoad(gameObject);

            Initialize();
        }

        private void Initialize()
        {
            //Create state objects
            MainMenuState mainMenu = new MainMenuState();
            InGameState ingame = new InGameState();
            OptionsState options = new OptionsState();
            GoodGameState goodGame = new GoodGameState();
            HighScoreState highScore = new HighScoreState();


            states.Add(mainMenu);
            states.Add(ingame);
            states.Add(options);
            states.Add(goodGame);
            states.Add(highScore);


#if UNITY_EDITOR //A pre-processor directive. This code block is removed from build.
            foreach (GameStateBase state in states)
            {
                string activeSceneName = SceneManager.GetActiveScene().name.ToLower();

                int index = 0;
                if (activeSceneName.StartsWith("level"))
                {
                    index = int.Parse(activeSceneName.Substring(5, 1));
                }

                string sceneName = state.SceneName.ToLower();
                if (sceneName.StartsWith("level"))
                {
                    sceneName = "level";
                }
                
                if (sceneName == activeSceneName)
                {
                    ActivateFirstScene(state, index);
                    break; //Early exit from the loop.
                }
            }
#endif

            if (CurrentState == null)
            {
                ActivateFirstScene(mainMenu);
            }
        }

        private void ActivateFirstScene(GameStateBase first, int index = 0)
        {
            CurrentState = first;
            CurrentState.Activate(index);
        }

        private GameStateBase GetState(StateType type)
        {
            foreach (GameStateBase state in states)
            {
                if (state.Type == type)
                {
                    return state;
                }
            }

            return null;
        }

        public bool Go(StateType targetStateType, int levelIndex = 0)
        {
            Debug.Log($"Transitioning to the {targetStateType}");
            //Check the legality of the transition
            if (!CurrentState.IsValidTarget(targetStateType))
            {
                Debug.Log($"{targetStateType} is not valid target for {CurrentState.Type}");
                return false;
            }


            //Find the state that matches the targetStateType
            GameStateBase nexState = GetState(targetStateType);
            if (nexState == null)
            {
                Debug.Log($"No state exist that represents the {targetStateType}");
                return false;
            }

            //Transition from current state to the target state
            PreviousState = CurrentState;

            CurrentState.Deactivate();
            CurrentState = nexState;
            CurrentState.Activate(levelIndex);

            return true;
        }
        /// <summary>
        /// Transitions back to the previous state.
        /// </summary>
        /// <returns>True, if the transition succeeds. False otherwise.</returns>
        public bool GoBack()
        {
            return Go(PreviousState.Type, PreviousState.LevelIndex);
        }
    }
}
