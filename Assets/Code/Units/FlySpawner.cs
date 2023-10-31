using System;
using System.Collections;
using UnityEngine;

namespace GP2.Derri.Utils
{
    public class FlySpawner : PooledSpawner<Fly>
    {
        [SerializeField]
        private float spawnRate = 1;

        [SerializeField]
        private float aliveTime = 1;

        private void Start()
        {
            Setup();
            StartCoroutine(TimedSpawn());
        }

        private IEnumerator TimedSpawn()
        {
            while (true)
            {
                Fly fly = Create(transform.position, transform.rotation, null);

                if (fly != null)
                {
                    //Initializes the flies alive timer.
                    fly.Setup(aliveTime);
                    //If fly is null, pool run out of fly objects.
                    fly.Expired += OnExpired;
                }

                yield return new WaitForSeconds(spawnRate);
            }
        }

        private void OnExpired(Fly fly)
        {
            fly.Expired -= OnExpired;
            Recycle(fly);
        }
    }
}