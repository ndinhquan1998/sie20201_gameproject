using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DQ
{
    public class GameManager : MonoBehaviour
    {
        public int levelEndBGM = 8;
        private string levelToLoad = "Level Select";
        private bool isPaused;

        UIManager uiManager;
        InputHandler inputHandler;
        PlayerStats playerStats;
        PlayerInventory playerInventory;


        public int lostCoin;
        public int lostExp;

        public static GameManager instance;
        // Start is called before the first frame update
        void Start()
        {
            CheckSaveFile();
            CheckCoins();
            CheckExp();
            //CheckSavedProfile();

            GetPlayerDeathLoot();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            inputHandler = FindObjectOfType<InputHandler>();
            playerStats = FindObjectOfType<PlayerStats>();
            playerInventory = FindObjectOfType<PlayerInventory>();
            instance = this;
 
        }

        public void PauseUnpause()
        {
            if (!isPaused)
            {
                uiManager.pauseScreen.SetActive(true);
                uiManager.hudWindow.SetActive(false);
                isPaused = true;

                Time.timeScale = 0f;
            }
            else
            {
                uiManager.pauseScreen.SetActive(false);
                uiManager.hudWindow.SetActive(true);
                isPaused = false;

                Time.timeScale = 1f;
            }
        }

        public void Respawn()
        {
            SavePlayerDeathLoot();
            StartCoroutine(Restart());
        }
        IEnumerator Restart()
        {                    
            uiManager.fadeToBlack = true;
            uiManager.hudWindow.SetActive(false);

            RGBColor col = new RGBColor(255, 200, 0);
            Color c = col.getRGBColor;
            UpdateStatus(c, "You Died");           
            
            yield return new WaitForSeconds(4f);
            uiManager.loadingScreen.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);           
            CheckSaveFile();      
            uiManager.fadeFromBlack = true;
        }

        public void LevelEndCo()
        {
            //AudioManager.PlayMusic(levelEndBGM);
            //yield return new WaitForSeconds(2f);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
            SavePlayerCurrency();
            //PlayerPrefs.SetInt("_coins", playerStats.coinCount);
            //PlayerPrefs.SetInt("_exps", playerStats.expCount);
            
            StartCoroutine(LoadScene(levelToLoad));
        }

        public IEnumerator LoadScene(string level)
        {
            uiManager.fadeToBlack = true;
            uiManager.hudWindow.SetActive(false);
            uiManager.loadingScreen.SetActive(true);
            yield return new WaitForSeconds(2f);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);

            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= .9f)
                {
                    uiManager.loadingText.text = "Press any key to continue";
                    uiManager.loadingIcon.SetActive(false);

                    if (inputHandler.any_Input)
                    {
                        asyncLoad.allowSceneActivation = true;

                        Time.timeScale = 1f;
                    }
                }

                yield return null;
            }
        }

        public void UpdateStatus(Color c, string t)
        {
            uiManager.showText = true;
            uiManager.status.text = t;
            uiManager.status.color = c;            
        }

        private void CheckSaveFile()
        {
            SaveFile save = Serialization.GetSaveFile();

            SaveableMonoBehaviour[] saveables = GameObject.FindObjectsOfType<SaveableMonoBehaviour>();
            Dictionary<string, SaveableMonoBehaviour> savedDict = new Dictionary<string, SaveableMonoBehaviour>();
            for (int i = 0; i < saveables.Length; i++)
            {
                savedDict.Add(saveables[i].saveID, saveables[i]);
            }
            if (save != null)
            {
                foreach( SaveTransform s in save.savedMonobehaviors)
                {
                    if (s.saveID == null)
                        continue;
                    savedDict.TryGetValue(s.saveID, out SaveableMonoBehaviour result);
                    if(result != null)
                    {
                        result.LoadSavedTransform(s);
                    }
                }
            }
        }

        private void CheckSavedProfile()
        {
            SaveProfile save = Serialization.GetSavedProfileFile();
            if(save != null)
            {
                playerInventory.playerProfile.weaponsInRightHandSlot = save.weaponsInRightHandSlot;
                playerInventory.playerProfile.weaponsInLeftHandSlot = save.weaponsInLeftHandSlot;
            }
        }

        public void Saving()
        {
            SaveFile save = new SaveFile();

            SaveableMonoBehaviour[] saveables = GameObject.FindObjectsOfType<SaveableMonoBehaviour>();

            foreach (SaveableMonoBehaviour s in saveables)
            {
                if (s.cannotSave)
                    continue;
                save.savedMonobehaviors.Add(s.GetSaveTransform());
            }

            Serialization.SaveToFile(save);
            //Serialization.SaveProfileToFile(playerInventory.playerProfile.GetSaveableProfile());

        }

        public void SavePlayerCurrency()
        {
            PlayerPrefs.SetInt("_coins", playerStats.coinCount);
            PlayerPrefs.SetInt("_exps", playerStats.expCount);
        }

        public void SavePlayerDeathLoot()
        {
            PlayerPrefs.SetInt("_coinsD", lostCoin);
            PlayerPrefs.SetInt("_expsD", lostExp);
        }

        public void GetPlayerDeathLoot()
        {
            if (PlayerPrefs.HasKey("_coinsD") && PlayerPrefs.HasKey("_expsD"))
            {
                Debug.Log("Lost" + PlayerPrefs.GetInt("_coinsD") + "exp and" + PlayerPrefs.GetInt("_expsD") + "coins");
            }
        }
        public void CheckCoins()
        {
            if (PlayerPrefs.HasKey("_coins"))
            {
                PlayerStats playerStats = FindObjectOfType<PlayerStats>();
                CurrencyCounter currencyCounter = FindObjectOfType<CurrencyCounter>();

                if (playerStats != null)
                {
                    playerStats.coinCount = PlayerPrefs.GetInt("_coins");
                    if (currencyCounter != null)
                    {
                        currencyCounter.SetCoinText(playerStats.coinCount);
                    }
                }

            }
        }
        public void CheckExp()
        {
            if (PlayerPrefs.HasKey("_exps"))
            {
                PlayerStats playerStats = FindObjectOfType<PlayerStats>();
                ExperienceCounter expCounter = FindObjectOfType<ExperienceCounter>();

                if (playerStats != null)
                {
                    playerStats.expCount = PlayerPrefs.GetInt("_exps");
                    if (expCounter != null)
                    {
                        expCounter.SetExpText(playerStats.expCount);
                    }
                }

            }
        }
    }

}
