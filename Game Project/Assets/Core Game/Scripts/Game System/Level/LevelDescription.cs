using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DQ
{
    public class LevelDescription : MonoBehaviour
    {
         public Text _nameText;
         public Text _descriptionText;
         public Image _previewImage;
        public string sceneName;

          
        public GameObject levelPanel;
        public static LevelDescription instance;
        LevelEntry levelEntry;

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
            levelEntry = FindObjectOfType<LevelEntry>() ;
        }

        // Update is called once per frame

        public void OpenWindow()
        {
            levelPanel.SetActive(true);
        }
        public void CloseWindows()
        {
            levelPanel.SetActive(false);
        }

        public void OnPlayPressed()
        {
            CloseWindows();
            levelEntry.StartMission();
        }
    }
}

