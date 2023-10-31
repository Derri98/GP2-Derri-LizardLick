using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace GP2.Derri.Save
{
    public class BinarySaver : ISaveSystem
    {
        private BinaryReader reader;
        private BinaryWriter writer;
        private FileStream currentSaveFile;

        public void FinalizeRead()
        {
            reader.Close();
            currentSaveFile.Close();

            reader = null;
            currentSaveFile = null;
        }

        public void FinalizeWrite()
        {
            writer.Close();
            currentSaveFile.Close();

            writer = null;
            currentSaveFile = null;
        }

        public bool PrepareRead(string savePath)
        {
            if (!File.Exists(savePath))
            {
                return false;
            }

            try
            {
                currentSaveFile = File.OpenRead(savePath);
                reader = new BinaryReader(currentSaveFile);
            }
            catch (Exception error)
            {
                Debug.LogException(error);
                return false;
            }

            return true;
        }

        public bool PrepareWrite(string savePath)
        {
            try
            { 
                string saveDirectory = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(saveDirectory))
                {
                    //Save Directory does not exist, lets create it.
                    Directory.CreateDirectory(saveDirectory);
                }

                currentSaveFile = File.Open(savePath, FileMode.Create);
                writer = new BinaryWriter(currentSaveFile);
            }
            catch(Exception error)
            {
                Debug.LogException(error);
                return false;
            }

            return true;
        }

        public bool ReadBool()
        {
            return reader.ReadBoolean();
        }

        public float ReadFloat()
        {
            return reader.ReadSingle();
        }

        public int ReadInt()
        {
            return reader.ReadInt32();
        }

        public string ReadString()
        {
            return reader.ReadString();
        }

        public void WriteBool(bool value)
        {
            writer.Write(value);
        }

        public void WriteFloat(float value)
        {
            writer.Write(value);
        }

        public void WriteInt(int value)
        {
            writer.Write(value);
        }

        public void WriteString(string value)
        {
            writer.Write(value);
        }
    }
}
