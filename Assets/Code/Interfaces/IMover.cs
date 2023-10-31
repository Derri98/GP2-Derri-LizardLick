using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
    public interface IMover
    {
        // Speed property defines the speed of the mover
        float Speed { get; }

        void Setup(float speed);

        // Direction: The direction we want to move the spaceship
        void Move(Vector3 direction);
    }
}
