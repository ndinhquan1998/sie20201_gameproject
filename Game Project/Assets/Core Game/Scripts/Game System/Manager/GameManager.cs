using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace DQ
{
    public class GameManager : MonoBehaviour
    {
 
        private bool isPaused;
 
        UIManager uiManager;
        // Start is called before the first frame update
        void Start()
        {
            CheckSaveFile();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
 
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
            StartCoroutine(Restart());
        }
        IEnumerator Restart()
        {
            
            
            uiManager.fadeToBlack = true;
            RGBColor col = new RGBColor(255, 200, 0);
            Color c = col.getRGBColor;
            UpdateStatus(c, "You Died");
            
            
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);           
            CheckSaveFile();      
            uiManager.fadeFromBlack = true;


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
        }
    }

}
