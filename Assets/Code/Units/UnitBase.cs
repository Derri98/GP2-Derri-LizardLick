/* Copyright (C) 2023 Sami Kojo - All Rights Reserved
 * You may use, distribute and modify this code under the
 * terms of the BSD 3-Clause License. The license can be found
 * from this repository. If not, please contact Sami Kojo, sami.kojo@tuni.fi.
 */

using GP2.Derri.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
    public abstract class UnitBase : MonoBehaviour
    {
		public AudioSource soundEffectAudio;

		[SerializeField]
		private float speed = 5;

		public IMover Mover
        {
			get;
			private set;
        }

		protected virtual void Awake()
		{
			Mover = GetComponent<IMover>();
			soundEffectAudio = GetComponent<AudioSource>();
		}
		protected virtual void Start()
		{
            //External dependency should not beinitialized in awake because we
            //cannot guarantee that its awake is called yet.
            Mover.Setup(speed);

		}

		protected abstract void Update();


		protected virtual void Die()
		{
			// Implement lives and respawn etc.
			// TODO: Explosion effect!
			gameObject.SetActive(false);
		}
	}
}
