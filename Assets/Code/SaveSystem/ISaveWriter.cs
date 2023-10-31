using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GP2.Derri.Save
{
    public interface ISaveWriter
    {
        bool PrepareWrite(string savePath);
        void FinalizeWrite();

        void WriteInt(int value);
        void WriteFloat(float value);
        void WriteString(string value);
        void WriteBool(bool value);
    }
}
