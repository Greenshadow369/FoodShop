using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private Canvas settingCanvas;

    [Header("Window")]
    [SerializeField] private RectTransform windowRect;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle lowToggle;
    [SerializeField] private Toggle mediumToggle;
    [SerializeField] private Toggle highToggle;
    [SerializeField] private Toggle ultraToggle;
    [SerializeField] private GameObject returnToMainMenuButton;

    private void Start()
    {
        bool isMainMenu = SceneManager.GetActiveScene().name == "MainMenu";

        returnToMainMenuButton.SetActive(!isMainMenu);
    }
    
    public void SetMusicVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        Debug.Log("Setting music volume to: " + dB);
        audioMixer.SetFloat("MusicVolume", dB);
    }

    public void SetSFXVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        Debug.Log("Setting SFX volume to: " + dB);
        audioMixer.SetFloat("SFXVolume", dB);
    }

    public void ChangeGameQuality()
    {
        if (lowToggle.isOn)
            QualitySettings.SetQualityLevel(1);
        else if (mediumToggle.isOn)
            QualitySettings.SetQualityLevel(2);
        else if (highToggle.isOn)
            QualitySettings.SetQualityLevel(3);
        else if (ultraToggle.isOn)
            QualitySettings.SetQualityLevel(5);

        Debug.Log(QualitySettings.names[QualitySettings.GetQualityLevel()]);
    }

    public void OpenSettings()
    {
        //Enable canvas
        settingCanvas.enabled = true;
        //Animate UI
        windowRect.DOAnchorPosY(1500, 0.2f)
            .From()
            .SetEase(Ease.InOutSine)
            .SetUpdate(true);
        //Pause time scale
        Time.timeScale = 0f;
        
        AudioManager.instance.MuteSFX();
    }

    public void CloseSettings()
    {
        //Disable canvas
        settingCanvas.enabled = false;
        //Animate UI
        windowRect.DOAnchorPosY(0, 0.2f)
            .SetEase(Ease.InOutSine)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                Time.timeScale = 1f;
                AudioManager.instance.UnmuteSFX();
            });
        //Resume time scale
        Time.timeScale = 1;
    }
}
