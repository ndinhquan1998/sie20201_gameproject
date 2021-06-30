using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class SaveableMonoBehaviour : MonoBehaviour
    {
        PlayerManager playerManager;
        public string saveID;
        public bool cannotSave;


        public void LoadSavedTransform(SaveTransform save)
        {
            transform.position = save.position.GetValues();
            transform.eulerAngles = save.eulers.GetValues();

        }
        private void Awake()
        {
            playerManager = FindObjectOfType<PlayerManager>();
            if (string.IsNullOrEmpty(saveID))
            {
                saveID = transform.name;
            }
        }
        public SaveTransform GetSaveTransform()
        {
            if (cannotSave)
                return null;

            SaveTransform result = new SaveTransform();
            result.position = new SaveableVector(transform.position);
            result.eulers = new SaveableVector(transform.eulerAngles);

            result.saveID = saveID;
            return result;
        }
    }
    [System.Serializable]
    public class SaveTransform
    {
        public string saveID;
        public SaveableVector position;
        public SaveableVector eulers;
    }
}