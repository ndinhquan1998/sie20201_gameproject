using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace DQ
{
    public class OptionsMenu : MonoBehaviour
    {
        public Toggle fullscreenTog, vsyncTog;

        public ResItem[] resolutions;

        public int selectedResolution;

        public Text resolutionLabel;

        public AudioMixer theMixer;

        public Slider mastSlider, musicSlider, sfxSlider;
        public Text mastLabel, musicLabel, sfxLabel;

        public AudioSource sfxLoop;

        // Start is called before the first frame update
        void Start()
        {


            fullscreenTog.isOn = Screen.fullScreen;

            if (QualitySettings.vSyncCount == 0)
            {
                vsyncTog.isOn = false;
            }
            else
            {
                vsyncTog.isOn = true;
            }

            //search for resolution in list
            bool foundRes = false;
            for (int i = 0; i < resolutions.Length; i++)
            {
                if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
                {
                    foundRes = true;

                    selectedResolution = i;

                    UpdateResLabel();
                }
            }

            if (!foundRes)
            {
                resolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
            }


            if (PlayerPrefs.HasKey("MasterVol"))
            {
                theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
                mastSlider.value = PlayerPrefs.GetFloat("MasterVol");
            }

            if (PlayerPrefs.HasKey("MusicVol"))
            {
                theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
                musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
            }

            if (PlayerPrefs.HasKey("SFXVol"))
            {
                theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
                sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
            }

            mastLabel.text = (Mathf.RoundToInt(mastSlider.value * 100)).ToString() + "%";
            musicLabel.text = (Mathf.RoundToInt(musicSlider.value * 100)).ToString() + "%";
            sfxLabel.text = (Mathf.RoundToInt(sfxSlider.value * 100)).ToString() + "%";
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ResLeft()
        {
            selectedResolution--;
            if (selectedResolution < 0)
            {
                selectedResolution = 0;
            }

            UpdateResLabel();
        }

        public void ResRight()
        {
            selectedResolution++;
            if (selectedResolution > resolutions.Length - 1)
            {
                selectedResolution = resolutions.Length - 1;
            }

            UpdateResLabel();
        }

        public void UpdateResLabel()
        {
            resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
        }

        public void ApplyGraphics()
        {
            //apply fullscreen
            //Screen.fullScreen = fullscreenTog.isOn;

            if (vsyncTog.isOn)
            {
                QualitySettings.vSyncCount = 1;
            }
            else
            {
                QualitySettings.vSyncCount = 0;
            }

            //set resolution
            Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
        }

        public void SetMasterVol()
        {

            mastLabel.text = (Mathf.RoundToInt(mastSlider.value * 100)).ToString() + "%";

            theMixer.SetFloat("MasterVol", Mathf.Log10(mastSlider.value) * 20);

            PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
        }

        public void SetMusicVol()
        {
            musicLabel.text = (Mathf.RoundToInt(musicSlider.value * 100)).ToString() + "%";

            theMixer.SetFloat("MusicVol", Mathf.Log10(musicSlider.value) * 20);

            PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
        }

        public void SetSFXVol()
        {
            sfxLabel.text = (Mathf.RoundToInt(sfxSlider.value * 100)).ToString() + "%";

            theMixer.SetFloat("SFXVol", Mathf.Log10(sfxSlider.value) * 20);

            PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
        }

        public void PlaySFXLoop()
        {
            sfxLoop.Play();
        }

        public void StopSFXLoop()
        {
            sfxLoop.Stop();
        }
    }

    [System.Serializable]
    public class ResItem
    {
        public int horizontal, vertical;
    }

}