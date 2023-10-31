using UnityEngine;

namespace GP2.Derri.States
{
    public class InGameState : GameStateBase
    {
        public override string SceneName
        {
            get { return "Level" + LevelIndex; }
        }
        public override StateType Type
        {
            get { return StateType.InGame; }
        }

        public InGameState() : base()
        {
            AddTargetState(StateType.Options);
            AddTargetState(StateType.InGame);
            AddTargetState(StateType.GoodGame);
        }

        public override void Activate(int levelIndex = 0, bool forceLoad = false)
        {
            LevelIndex = levelIndex;

            //Calls the base class's implementation.
            base.Activate(levelIndex, forceLoad);

            //Unpause the game:
            Time.timeScale = 1;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            //Pause the game:
            Time.timeScale = 0;
        }
    }
}
