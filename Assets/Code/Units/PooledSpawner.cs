using System.Collections;
using UnityEngine;

namespace GP2.Derri.Utils
{
    public class PooledSpawner<TComponent> : Spawner<TComponent>
        where TComponent : Component
    {
        [SerializeField]
        private int capacity = 1;

        private ComponentPool<TComponent> pool;

        public override void Setup(TComponent prefab = null)
        {
            base.Setup(prefab);

            pool = new ComponentPool<TComponent>(Prefab, capacity);
        }

        public override TComponent Create(Vector3 position, Quaternion rotation, Transform parent)
        {
            TComponent item = pool.Get();
            if (item != null)
            {
                //If the parent is null, Unity will put the gameObject to scenes root level.
                item.transform.parent = parent;
                item.transform.localPosition = position;
                item.transform.localRotation = rotation;
            }

            return item;
        }

        public override bool Recycle(TComponent item)
        {
            return pool.Return(item);
        }

    }
}