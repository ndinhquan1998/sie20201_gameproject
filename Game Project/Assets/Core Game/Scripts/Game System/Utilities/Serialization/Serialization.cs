using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace DQ
{
    public class Serialization
    {
        #region Save Position
        public static void SaveToFile(SaveFile save)
        {
            string saveLocation = SaveLocation();
            saveLocation += "savedata.data";

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None)) {
                formatter.Serialize(stream, save);
            }
                

        }

        public static SaveFile GetSaveFile()
        {
            SaveFile result = null;
            DirectoryInfo dirInfo = new DirectoryInfo(SaveLocation());
            FileInfo[] fileInfo = dirInfo.GetFiles();

            foreach (FileInfo f in fileInfo)
            {
                string[] readName = f.Name.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (readName.Length == 2)
                {
                    if(string.Equals("savedata", readName[0])) { 

                        if (string.Equals("data", readName[1]))
                        {
                            IFormatter formatter = new BinaryFormatter();
                            using (FileStream stream = new FileStream(dirInfo + f.Name, FileMode.Open))  {
                                result = (SaveFile)formatter.Deserialize(stream);
                            }
                            break;
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region Save Profile
        public static void SaveProfileToFile(SaveProfile save)
        {
            string saveLocation = SaveLocation();
            saveLocation += "profile.data";

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, save);
            }
        }

        public static SaveProfile GetSavedProfileFile()
        {
            SaveProfile result = null;
            DirectoryInfo dirInfo = new DirectoryInfo(SaveLocation());
            FileInfo[] fileInfo = dirInfo.GetFiles();

            foreach (FileInfo f in fileInfo)
            {
                string[] readName = f.Name.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (readName.Length == 2)
                {
                    if (string.Equals("profile", readName[0]))
                    {
                        if (string.Equals("data", readName[1]))
                        {
                            IFormatter formatter = new BinaryFormatter();
                            using (FileStream stream = new FileStream(dirInfo + f.Name, FileMode.Open))
                            {
                                result = (SaveProfile)formatter.Deserialize(stream);
                            }
                            break;
                        }
                    }
                }
            }
            return result;
        }
        #endregion


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
        public Weapon[] weaponsInRightHandSlot = new Weapon[2];
        public Weapon[] weaponsInLeftHandSlot = new Weapon[2];
    }
    [Serializable]
    public class SaveFile
    {
        public List<SaveTransform> savedMonobehaviors = new List<SaveTransform>();
    }

    [Serializable]
    public class SaveableItem
    {
        float x;
        float y;
        float z;


        public Vector3 GetValues()
        {
            return new Vector3(x, y, z);
        }
        public SaveableItem(Vector3 p)
        {
            x = p.x;
            y = p.y;
            z = p.z;
        }
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
