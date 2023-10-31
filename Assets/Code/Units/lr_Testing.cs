using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
    public class lr_Testing : MonoBehaviour
    {
        [SerializeField]
        private Transform[] points;

        [SerializeField]
        private LizardsTongue line;

        private void Start()
        {
            line.SetUpLine(points);
        }
    }
}
