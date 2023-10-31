using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace GP2.Derri.Save
{
    public class SaveSystem
    {
        private ISaveReader reader;
        private ISaveWriter writer;

        public string SaveFolder
        {
            get
            {
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(documents, "LizardLick", "Save");
            }
        }

        public string FileExtension
        {
            get { return ".save"; }
        }

        public SaveSystem(ISaveReader reader, ISaveWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Save(string saveFilePath)
        {
            throw new NotImplementedException();
        }

        public void Load(string saveFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
