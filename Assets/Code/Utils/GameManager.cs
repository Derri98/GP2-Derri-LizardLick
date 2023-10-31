using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GP2.Derri.Save;

namespace GP2.Derri
{
    public class GameManager : Singleton<GameManager>
    {
        private SaveSystem saveSystem;

        public SaveSystem SaveSystem
        {
            get { return saveSystem; }
        }
        protected override void Initialize()
        {
            base.Initialize();

            ISaveSystem saver = new BinarySaver();
            saveSystem = new SaveSystem(saver, saver);
        }
    }
}
