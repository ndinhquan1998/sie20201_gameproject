using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DQ
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject optionsScreen, pauseScreen;
        public GameObject loadingScreen, loadingIcon;
        public string mainMenuScene;
        private bool isPaused;
        public Text loadingText;

        PlayerControls inputActions;

        public bool menu_Input;
        public bool any_Input;

        // Start is called before the first frame update
        void LateUpdate()
        {
            menu_Input = false;
            any_Input = false;
        }
        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();

                inputActions.GameMenu.PauseGame.performed += i => menu_Input = true;
                inputActions.GameMenu.Anykey.performed += i => any_Input = true;
            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
        // Update is called once per frame
        void Update()
        {
            if (menu_Input)
            {
                PauseUnpause();
            }
        }

        public void PauseUnpause()
        {
            if (!isPaused)
            {
                pauseScreen.SetActive(true);
                isPaused = true;

                Time.timeScale = 0f;
            }
            else
            {
                pauseScreen.SetActive(false);
                isPaused = false;

                Time.timeScale = 1f;
            }
        }

        public void OpenOptions()
        {
            optionsScreen.SetActive(true);
        }

        public void CloseOptions()
        {
            optionsScreen.SetActive(false);
        }

        public void QuitToMain()
        {
            StartCoroutine(LoadMain());
        }

        public IEnumerator LoadMain()
        {
            loadingScreen.SetActive(true);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuScene);

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
    }
}

