using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri.Utils
{
    /// <summary>
    /// A pool which pools Unity objects.
    /// </summary>
    /// <typeparam name="T">The type has to bederived from UnityEngine.Object in order
    /// Unitys prefab system to be able to instantiate pooled objects.</typeparam>
    public abstract class Pool<T>
        where T : UnityEngine.Object
    {
        private T prefab;
        private List<T> items;

        /// <summary>
        /// Creates a new Pool.
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="capacity"></param>
        protected Pool(T prefab, int capacity)
        {
            this.prefab = prefab;
            this.items = new List<T>(capacity);

            for(int i = 0; i < capacity; i++)
            {
                Add();
            }
        }

        /// <summary>
        /// Gets the first inactive item from the pool.
        /// </summary>
        /// <returns>The first inactive object from the pool if there are any. Null otherwise.</returns>
        public virtual T Get()
        {
            T item = null;

            for (int i = 0; i < items.Count; i++)
            {
                T currentItem = items[i];
                if (currentItem != null && !IsActive(currentItem))
                {
                    item = currentItem;

                    //Break interrupts the iteration of the loop.
                    //The result is found so no point in continuing.
                    break;
                }
                else if (currentItem == null)
                {
                    Debug.LogError("Pooled item is null! An item is destroyed from the pool!" + 
                        "\nThis is a bug! Please report it to the developer. Thanks!");
                }
            }

            if (item != null)
            {
                SetActive(item, setActive: true);
            }

            return item;
        }

        /// <summary>
        /// Returns all the objects which are active when this method is called.
        /// </summary>
        /// <returns>List of active items.</returns>
        public List<T> GetActiveItems()
        {
            List<T> activeItems = new List<T>();
            foreach (T item in this.items)
            {
                if (IsActive(item))
                {
                    activeItems.Add(item);
                }
            }

            return activeItems;
        }

        /// <summary>
        /// Returns an item back to the pool to be recycled.
        /// </summary>
        /// <param name="item">Item to be returned back to pool.</param>
        /// <returns>True, if the item was returned successfully. False otherwise.</returns>
        public bool Return(T item)
        {
            if (!IsActive(item))
            {
                //Item is already deactivated, no need to return it.
                return false;
            }

            for (int i = 0; i <= items.Count; i++)
            {
                T currentItem = items[i];
                if (currentItem == item)
                {
                    //Item is present in this pool, lets deactivate it.
                    SetActive(item, setActive: false);
                    return true;
                }
            }

            //Item was not present in this pool. It cannot be returned here.
            return false;
        }

        /// <summary>
        /// Returns all pooled objects back to the pool.
        /// </summary>
        public void Reset()
        {
            foreach (var item in items)
            {
                SetActive(item, false);
            }
        }

        /// <summary>
        /// Activates (or deactivates) an item.
        /// </summary>
        /// <param name="item">The item to be (de)activated.</param>
        /// <param name="setActive">Should the item be activated or deactivated.</param>
        protected abstract void SetActive(T item, bool setActive);

        /// <summary>
        /// Chechs wether the item is active or not.
        /// </summary>
        /// <param name="item">The inspected item.</param>
        /// <returns></returns>
        protected abstract bool IsActive(T item);

        /// <summary>
        /// Adds a new item to a pool. the item is created from the prefab.
        /// </summary>
        /// <param name="setActive">Should the item be activated by default.</param>
        /// <returns>The created item.</returns>
        private T Add(bool setActive = false)
        {
            //Create a new object from a prefab.
            T item = UnityEngine.Object.Instantiate(this.prefab);

            //Disable pooled objects by default.
            SetActive(item, setActive: setActive);

            //Add the item to the pool
            this.items.Add(item);

            return item;
        }
    }
}
