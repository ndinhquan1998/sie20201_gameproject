using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DQ
{
    public static class Serialization
    {
        public static void SaveToFile(SaveFile save)
        {
            string saveLocation = SaveLocation();
            saveLocation += "savedata.data";

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, save);
            stream.Close();
        }

        public static SaveFile GetSaveFile()
        {
            SaveFile result = null;
            DirectoryInfo dirInfo = new DirectoryInfo(SaveLocation());
            FileInfo[] fileInfo = dirInfo.GetFiles();

            foreach (FileInfo f in fileInfo)
            {
                string[] readName = f.Name.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if(readName.Length == 2)
                {

                    if (string.Equals("data", readName[1]))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        FileStream stream = new FileStream(dirInfo + f.Name, FileMode.Open);
                        result = (SaveFile)formatter.Deserialize(stream);
                        stream.Close();
                        break;
                    }
                }
            }
            return result;
        }

        static string SaveLocation()
        {
            string saveLocation = Application.dataPath + "/Saves/";

            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);

            }
            return saveLocation;
        }
    }

    [Serializable]
    public class SaveProfile
    {
        public List<SaveTransform> savedMonobehaviors = new List<SaveTransform>();
    }
    [Serializable]
    public class SaveFile
    {
        public List<SaveTransform> savedMonobehaviors = new List<SaveTransform>();
    }

    [Serializable]
    public class SaveableVector
    {
        float x;
        float y;
        float z;


        public Vector3 GetValues()
        {
            return new Vector3(x, y, z);
        }
        public SaveableVector(Vector3 p)
        {
            x = p.x;
            y = p.y;
            z = p.z;
        }
    }
}
