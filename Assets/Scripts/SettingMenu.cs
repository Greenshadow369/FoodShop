using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle lowToggle;
    [SerializeField] private Toggle mediumToggle;
    [SerializeField] private Toggle highToggle;
    [SerializeField] private Toggle ultraToggle;
    
    public void SetVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        Debug.Log("Setting volume to: " + dB);
        audioMixer.SetFloat("MusicVolume", dB);
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
}
