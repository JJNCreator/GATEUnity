using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUIFromSaveFile : MonoBehaviour
{
    public enum SettingType
    {
        VSync = 0,
        Resolution = 1,
        Fullscreen = 2,
        QualityLevel = 3,
        MasterVolume = 4,
        MusicVolume = 5,
        SFXVolume = 6,
        XSensitivity = 7,
        YSensitivity = 8,
        XInverted = 9,
        YInverted = 10,
        MotionBlur = 11
    }
    public SettingType type;
    // Start is called before the first frame update
    void Start()
    {
        UpdateValue();
    }

    private void UpdateValue()
    {
        switch(type)
        {
            case SettingType.VSync:
                GetComponent<Toggle>().isOn = GameSettings.VSync;
                break;
            case SettingType.Resolution:
                GetComponent<TMP_Dropdown>().value = GameSettings.ResolutionChoice;
                break;
            case SettingType.Fullscreen:
                GetComponent<Toggle>().isOn = GameSettings.Fullscreen;
                break;
            case SettingType.QualityLevel:
                GetComponent<TMP_Dropdown>().value = GameSettings.QualityLevelChoice;
                break;
            case SettingType.MasterVolume:
                GetComponent<Slider>().value = GameSettings.MasterVolume;
                break;
            case SettingType.MusicVolume:
                GetComponent<Slider>().value = GameSettings.MusicVolume;
                break;
            case SettingType.SFXVolume:
                GetComponent<Slider>().value = GameSettings.SFXVolume;
                break;
            case SettingType.XSensitivity:
                GetComponent<Slider>().value = GameSettings.XSensitivity;
                break;
            case SettingType.YSensitivity:
                GetComponent<Slider>().value = GameSettings.YSensitivity;
                break;
            case SettingType.XInverted:
                GetComponent<Toggle>().isOn = GameSettings.XInverted;
                break;
            case SettingType.YInverted:
                GetComponent<Toggle>().isOn = GameSettings.YInverted;
                break;
            case SettingType.MotionBlur:
                GetComponent<Toggle>().isOn = GameSettings.MotionBlur;
                break;
        }
    }
}
