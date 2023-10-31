/* Copyright (C) 2023 Sami Kojo - All Rights Reserved
 * You may use, distribute and modify this code under the
 * terms of the BSD 3-Clause License. The license can be found
 * from this repository. If not, please contact Sami Kojo, sami.kojo@tuni.fi.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicsMover : MonoBehaviour, IMover
    {
        private new Rigidbody2D rigidbody;
        private Vector3 direction;

        public float Speed
        {
            get;
            private set;
        }

        public void Move(Vector3 direction)
        {
            this.direction = direction;
        }

        public void Setup(float speed)
        {
            Speed = speed;
            rigidbody = GetComponent<Rigidbody2D>();
            if (rigidbody == null)
            {
                Debug.LogError("Rigidbody2D can't be found!");
            }
        }

        private void FixedUpdate()
        {
            //Setup is not run just yet, early exit.
            if (rigidbody == null) 
            {
                return;
            }

            Move(Time.fixedDeltaTime);
        }

        private void Move(float deltaTime)
        {
            // Form the movement vector and add that to the current position.
            Vector2 movement = deltaTime * Speed * direction;
            Vector2 position = rigidbody.position;
            position += movement;
            rigidbody.MovePosition(position);

            // Movement direction is consumed. Reset it.
            direction = Vector3.zero;
        }
    }
}
