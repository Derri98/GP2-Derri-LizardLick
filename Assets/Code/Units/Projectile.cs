/* Copyright (C) 2023 Sami Kojo - All Rights Reserved
 * You may use, distribute and modify this code under the
 * terms of the BSD 3-Clause License. The license can be found
 * from this repository. If not, please contact Sami Kojo, sami.kojo@tuni.fi.
 */
/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5;

        [SerializeField]
        private float aliveTime = 5;

        private Vector2 direction = Vector2.zero;
        private IMover mover;
        private bool isLaunched = false;
        private Coroutine aliveTimerRoutine = null;
        private float aliveTimer = 0;

        public event Action<Projectile> Expired;

        private void Awake()
        {
            mover = GetComponent<IMover>();
            if (mover == null)
            {
                Debug.LogError("Mover is not found!");
            }
        }

        private void OnMouseDown()
        {
            Recycle();
        }

        private void FixedUpdate()
        {
            if (isLaunched)
            {
                mover.Move(this.direction);
            }
        }

        public void Setup(float speed = -1)
        {
            //Override the default speed if the provided parameter is positive
            if (speed < 0)
            {
                speed = this.speed;
            }
            mover.Setup(speed);

            this.isLaunched = false;
        }

        public void Launch(Vector2 direction)
        {
            this.direction = direction;
            this.isLaunched = true;

            aliveTimerRoutine = StartCoroutine(AliveTimer(this.aliveTimer));
        }

        private void Recycle()
        {
            if (aliveTimerRoutine != null)
            {
                StopCoroutine(aliveTimerRoutine);
                aliveTimerRoutine = null;
            }
            if (Expired != null)
            {
                Expired(this);
            }
        }

        /// <summary>
        /// Destroys the object when its aliveTime has passed.
        /// </summary>
        /// <returns>The IEnumerator for coroutine to continue the execution.</returns>
        private IEnumerator AliveTimer(float aliveTime)
        {
            aliveTimer = aliveTime;
            while (aliveTimer > 0)
            {
                aliveTimer -= Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(aliveTime);

            //Notify the event receivers that the projectile should be recycled.
            Recycle();
        }

    }
}
*/