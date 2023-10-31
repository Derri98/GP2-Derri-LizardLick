using GP2.Derri.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GP2.Derri
{
    public class PlayerLizard : UnitBase
    {
        protected override void Awake()
        {
            base.Awake();

        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {

        }

        public void Pause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                GameStateManager.Instance.Go(StateType.Options);
            }
        }
    }
}
