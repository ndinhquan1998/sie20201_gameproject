using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DQ
{
    public class MainMenu : MonoBehaviour
    {
        public string levelSelect;

        public GameObject optionsScreen;
        public GameObject continueButton;
        public GameObject loadingScreen, loadingIcon;
        public Text loadingText;

        PlayerControls inputActions;

        public string[] levelNames;

        private bool any_Input;
        // Start is called before the first frame update
        private void Start()
        {
            if (PlayerPrefs.HasKey("Continue"))
            {
                continueButton.SetActive(true);
            } else
            {
                ResetProgress();
            }
        }

        // Update is called once per frame
        void LateUpdate()
        {
            any_Input = false;
        }

        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.GameMenu.Anykey.performed += i => any_Input = true;
            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void ContinueGame()
        {
            //SceneManager.LoadScene(firstLevel);
            StartCoroutine(LoadSave());
        }
        public void StartGame()
        {
            //SceneManager.LoadScene(firstLevel);
            StartCoroutine(LoadStart());
            PlayerPrefs.SetInt("Continue", 0);
            PlayerPrefs.SetString("CurrentLevel", levelSelect);
            ResetProgress();
        }

        public void OpenOptions()
        {
            optionsScreen.SetActive(true);
        }

        public void CloseOptions()
        {
            optionsScreen.SetActive(false);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public IEnumerator LoadStart()
        {
            loadingScreen.SetActive(true);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Tutorial Scene");

            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= .9f)
                {
                    loadingText.text = "Press any key to continue";
                    loadingIcon.SetActive(false);

                    if (any_Input)
                    {
                        asyncLoad.allowSceneActivation = true;

                        Time.timeScale = 1f;
                    }
                }

                yield return null;
            }
        }


        public IEnumerator LoadSave()
        {
            loadingScreen.SetActive(true);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level Select");

            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= .9f)
                {
                    loadingText.text = "Press any key to continue";
                    loadingIcon.SetActive(false);

                    if (any_Input)
                    {
                        asyncLoad.allowSceneActivation = true;

                        Time.timeScale = 1f;
                    }
                }

                yield return null;
            }
        }

        public void ResetProgress()
        {
            for(int i =0; i< levelNames.Length; i++)
            {
                PlayerPrefs.SetInt(levelNames[i] + "_unlocked", 0);
            }
        }
    }

}