using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DQ
{
    public class LevelEntry : Interactable
    {
        //public string levelName, levelToCheck;
        private bool levelUnlocked;
        public GameObject checkpointActive, checkpointInactive;
        public MissionSpecs missionSpecs;
        public static LevelEntry instance;

        PlayerStats playerStats;
        LevelDescription levelDescription;

        private void Awake()
        {
            //gameManager = FindObjectOfType<GameManager>();
            playerStats = FindObjectOfType<PlayerStats>();
            levelDescription = FindObjectOfType<LevelDescription>();
            instance = this;
            
        }

        private void Start()
        {
            if(PlayerPrefs.GetInt(missionSpecs.LevelToCheck + "_unlocked") == 1 || missionSpecs.LevelToCheck == "")
            {
                checkpointActive.SetActive(true);
                checkpointInactive.SetActive(false);
                levelUnlocked = true;
            } 
            else
            {
                checkpointActive.SetActive(false);
                checkpointInactive.SetActive(true);
                levelUnlocked = false;
            }

            if(PlayerPrefs.GetString("CurrentLevel") == missionSpecs.SceneName)
            {
                playerStats.transform.position = transform.position ;
                
            }
        }

        public void UpdateInfo()
        {
            string text_N = missionSpecs?.Name;
            string text_D = missionSpecs?.Description;
            string text_S = missionSpecs?.SceneName;
            LevelDescription.instance._nameText.text = text_N;
            LevelDescription.instance._descriptionText.text = text_D;
            LevelDescription.instance._previewImage.sprite = missionSpecs?.Image;
            LevelDescription.instance.sceneName = text_S;
            Debug.Log(LevelDescription.instance.sceneName);
            LevelDescription.instance._previewImage.color = Color.white;
        }

        public void StartMission()
        {
            Debug.Log(LevelDescription.instance.sceneName);
            StartCoroutine(GameManager.instance.LoadScene(LevelDescription.instance.sceneName));
            PlayerPrefs.SetString("CurrentLevel", LevelDescription.instance.sceneName);
        }

        public override void Interact(PlayerManager playerManager)
        {         
            if (levelUnlocked)
            {
                UpdateInfo();
                LevelDescription.instance.OpenWindow();

            }
        }

    }
}
