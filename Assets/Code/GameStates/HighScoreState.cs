using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri.States
{
    public class HighScoreState : GameStateBase
    {
        public override string SceneName { get { return "HighScore"; } }

        public override StateType Type { get { return StateType.HighScore; } }

        public HighScoreState() : base()
        {
            AddTargetState(StateType.MainMenu);
            AddTargetState(StateType.InGame);
        }
    }
}
