using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri
{
	public abstract class Singleton<T> : MonoBehaviour
		where T : Singleton<T> // Limits the type T. In this case T must be derived from the Singleton class.
	{
		private static T instance;

		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					string resourceToLoad = typeof(T).Name;
					T prefab = Resources.Load<T>(resourceToLoad);
					if (prefab == null)
					{
						throw new System.NullReferenceException($"Prefab for Singleton {resourceToLoad} can't be load!");
						// throw new System.NullReferenceException("Prefab for Singleton " + resourceToLoad + " can't be load!");
					}

					instance = Instantiate(prefab);
				}
				return instance;
			}
		}

		private void Awake()
		{
			if (instance == null)
			{
				// This is the only possible instance of the class
				instance = this as T;
			}
			else if (instance != this)
			{
				// There is already one instance. Let's destroy the new one
				Destroy(gameObject);
				return;
			}

			// All additional instantiation comes here
			// This GameObject won't be unloaded during the scene transition
			DontDestroyOnLoad(gameObject);

			Initialize();
		}

		protected virtual void Initialize()
		{
		}
	}
}
