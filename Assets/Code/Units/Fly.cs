using GP2.Derri.Config;
using GP2.Derri.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
    public class Fly : UnitBase
    {
        private Coroutine aliveTimer;

        public event Action<Fly> Expired;

        public void Setup(float aliveTime)
        {
            aliveTimer = StartCoroutine(AliveTimer(aliveTime));
        }

        protected override void Update()
        {
            Mover.Move(transform.up);
        }

        private void OnMouseDown()
        {
            //Update the UI
            ScoreManager.instance.AddPoint();

            OnExpired();



        }

        private void OnExpired()
        {

            //Stop the coroutine if its still running.
            if (aliveTimer != null)
            {
                StopCoroutine(aliveTimer);
                aliveTimer = null;
            }
            Expired?.Invoke(this);
        }

        private IEnumerator AliveTimer(float aliveTime)
        {
            yield return new WaitForSeconds(aliveTime);
            OnExpired();
        }
    }
}
