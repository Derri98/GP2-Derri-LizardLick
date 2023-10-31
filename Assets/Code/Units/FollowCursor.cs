using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
    public class FollowCursor : MonoBehaviour
    {
        [SerializeField]
        new Camera camera;

        Vector3 pos;
        public float speed = 1f;
        public static Vector3 mousePosition;

        private void Start()
        {

        }

        private void Update()
        {

            pos = Input.mousePosition;
            pos.z = speed;
            transform.position = camera.ScreenToWorldPoint(pos);
        }

    }
}
