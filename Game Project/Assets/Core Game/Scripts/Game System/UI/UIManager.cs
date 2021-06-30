using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DQ
{
    public class UIManager : MonoBehaviour
    {
        //[Header("Menu Screens")]
        public GameObject optionsScreen, pauseScreen;
        public GameObject loadingScreen, loadingIcon;
        public string mainMenuScene;
 
        public Text loadingText;
        InputHandler inputHandler;

        [Header("Transition")]
        public Image blackScreen;
        public Text status;
        public float fadeSpeed = 1f;
        public bool fadeToBlack, fadeFromBlack;
        public bool showText,fadeText;





        public GameManager gameManager;
        public PlayerInventory playerInventory;
        public EquipmentWindowUI equipmentWindowUI;

        //HUD
        [Header("UI WIndows")]
        public GameObject hudWindow;
        public GameObject selectWindow;
        public GameObject equipmentScreenWindow;
        public GameObject weaponInventoryWindow;

        [Header("Weapon Window Slot Selected")]
        public bool rightHandSlot01Selected;
        public bool rightHandSlot02Selected;
        public bool leftHandSlot01Selected;
        public bool leftHandSlot02Selected;
        
        [Header("Armor Equipment Window Slot Selected")]
        public bool helmetSlotSelected;
        public bool bodyArmorSlotSelected;
        public bool bottomArmorSlotSelected;
        
        [Header("Consumable Window Slot Selected")]
        public bool c_Slot01Selected;
        public bool c_Slot02Selected;
        public bool c_Slot03Selected;
        public bool c_Slot04Selected;
        
        [Header("Spell Window Slot Selected")]
        public bool spell_Slot01Selected;
        public bool spell_Slot02Selected;
        public bool spell_Slot03Selected;
        public bool spell_Slot04Selected;

        [Header("Weapon Inventory")]
        public GameObject weaponInventorySlotPrefab;
        public Transform weaponInventorySlotsParent;
        WeaponInventorySlot[] weaponInventorySlots;

/*        private void Awake()
        {
            equipmentWindowUI = FindObjectOfType<EquipmentWindowUI>();
        }*/
        private void Start()
        {
            weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
            inputHandler = FindObjectOfType<InputHandler>();
            gameManager = FindObjectOfType<GameManager>();
            equipmentWindowUI.LoadWeaponsOnEquipmentScreen(playerInventory);

        }

        private void Awake()
        {
            if (!fadeFromBlack)
            {
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, 1f);
                fadeFromBlack = true;
            }
        }
        private void Update()
        {
            EndScene();
            ShowStatus();
            if (inputHandler.menu_Input)
            {
                Resume();
            }
        }

        public GameObject bossUI;
        public GameObject bossPrefab;
        public Transform barGrid;

        public UIBossHealthBar AddBossBar()
        {
            GameObject go = Instantiate(bossPrefab);
            go.transform.SetParent(barGrid);
            go.transform.localScale = Vector3.one;
            go.SetActive(true);

            return go.GetComponentInChildren<UIBossHealthBar>();
        }


        private void EndScene()
        {
            if (fadeToBlack)
            {
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

                if (blackScreen.color.a == 1f)
                {
                    fadeToBlack = false;
                }
            }

            if (fadeFromBlack)
            {
                float alpha = Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime);
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);

                if (blackScreen.color.a == 0f)
                {
                    fadeFromBlack = false;
                    blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);
                }
            }
        }

        private void ShowStatus()
        {
            if (showText) {
                status.color = new Color(status.color.r, status.color.g,status.color.b, Mathf.MoveTowards(status.color.a, 1f, fadeSpeed * Time.deltaTime));
                showText = false;
                //fadeText = true;
            }
            fadeText = true;
            if (fadeText)
            {                
                status.color = new Color(status.color.r, status.color.g, status.color.b, Mathf.MoveTowards(status.color.a, 0f, 0.2f * Time.deltaTime));
                fadeText = false;
            }
        }

        public void UpdateUI()
        {
            #region Weapon Inventory Slots 
            for (int i = 0; i < weaponInventorySlots.Length; i++)
            {
                if (i < playerInventory.weaponsInventory.Count)
                {
                    if (weaponInventorySlots.Length < playerInventory.weaponsInventory.Count)
                    {
                        Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);
                        weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
                    }
                    weaponInventorySlots[i].AddItem(playerInventory.weaponsInventory[i]);
                }
                else
                {
                    weaponInventorySlots[i].ClearInventorySlot();
                }
            }
            #endregion
        }
        public void OpenSelectWindows()
        {
            selectWindow.SetActive(true);
        }        
        public void CloseSelectWindows()
        {
            selectWindow.SetActive(false);
        }
        public void CloseAllInventoryWindow()
        {
            ResetAllSelectedSlots();
            weaponInventoryWindow.SetActive(false);
            equipmentScreenWindow.SetActive(false);
        }

        public void ResetAllSelectedSlots()
        {
            rightHandSlot01Selected = false;
            rightHandSlot02Selected = false;
            leftHandSlot01Selected = false;
            leftHandSlot02Selected = false;

            helmetSlotSelected = false;
            bodyArmorSlotSelected = false;
            bottomArmorSlotSelected = false;

            c_Slot01Selected = false;
            c_Slot02Selected = false;
            c_Slot03Selected = false;
            c_Slot04Selected = false;

            spell_Slot01Selected = false;
            spell_Slot02Selected = false;
            spell_Slot03Selected = false;
            spell_Slot04Selected = false;
        }


        public void Resume()
        {
                gameManager.PauseUnpause();
        }
        public void OpenOptions()
        {
            optionsScreen.SetActive(true);
        }

        public void CloseOptions()
        {
            optionsScreen.SetActive(false);
        }

        public void QuitMission()
        {
            RGBColor col = new RGBColor(255, 200, 0);
            Color c = col.getRGBColor;
            gameManager.UpdateStatus(c, "Mission Failed");
            gameManager.PauseUnpause();
            gameManager.LevelEndCo();
        }

        public void QuitToMain()
        {
            StartCoroutine(LoadMain());
            //gameManager.PauseUnpause();
            //StartCoroutine(gameManager.LoadScene(mainMenuScene));
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

                    if (inputHandler.any_Input)
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

