using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri.Save
{
    public interface ISaveReader
    {
        bool PrepareRead(string savePath);
        void FinalizeRead();

        int ReadInt();
        float ReadFloat();
        string ReadString();
        bool ReadBool();

    }
}
