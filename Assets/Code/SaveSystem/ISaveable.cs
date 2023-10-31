using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri.Save
{
    public interface ISaveable
    {
        SaveObjectType SaveType { get; }

        void Save(ISaveWriter writer);

        void Load(ISaveReader reader);
    }
}
