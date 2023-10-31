using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri.States
{
    public class GoodGameState : GameStateBase
    {
        public override string SceneName { get { return "GoodGame"; } }

        public override StateType Type { get { return StateType.GoodGame; } }

        public GoodGameState() : base()
        {
            AddTargetState(StateType.MainMenu);
            AddTargetState(StateType.InGame);
        }
    }
}
