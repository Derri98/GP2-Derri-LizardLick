using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load/Unload functionality for scenes.

namespace GP2.Derri
{
    public abstract class GameStateBase
    {
        private int levelIndex = 0;

        private List<StateType> targetStates = new List<StateType>();

        public abstract string SceneName { get; }
        public abstract StateType Type { get; }
        public virtual bool IsAdditive { get { return false; } }
        
        public virtual int LevelIndex
        {
            get { return levelIndex; }
            protected set { levelIndex = value; }
        }

        //A default constructor.
        protected GameStateBase()
        {

        }

        protected void AddTargetState(StateType targetStateType)
        {
            if (!targetStates.Contains(targetStateType))
            {
                targetStates.Add(targetStateType);
            }
        }

        protected void RemoveTargetState(StateType targetStateType)
        {
            targetStates.Remove(targetStateType);
        }

        //Activates the state. Loads the related scene as well.
        public virtual void Activate(int levelIndex = 0, bool forceLoad = false)
        {
            //The scene loading.
            //Loads the target scene if its not loaded yet.
            //Reference to currently loaded scene.
            Scene currentScene = SceneManager.GetActiveScene();
            if (forceLoad || currentScene.name.ToLower() != SceneName.ToLower())
            {
                //The target scene is not loaded, loads it.
                LoadSceneMode mode = IsAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single;

                //Handles the scene loading.
                SceneManager.LoadScene(SceneName, mode);
            }
        }

        public virtual void Deactivate()
        {
            //Unload the level if neccessary.
            if (IsAdditive)
            {
                SceneManager.UnloadSceneAsync(SceneName);
            }
        }

        //Checks if the targetStateType is valid for this state.
        public bool IsValidTarget(StateType targetStateType)
        {
            foreach (StateType stateType in targetStates)
            {
                if (stateType == targetStateType)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
