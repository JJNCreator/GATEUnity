using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public static bool VSync
    {
        get
        {
            return SaveFileManager.saveFile.vSync;
        }
        set
        {
            SaveFileManager.saveFile.vSync = value;
        }
    }
    public static int ResolutionChoice
    {
        get
        {
            return SaveFileManager.saveFile.resolutionChoice;
        }
        set
        {
            SaveFileManager.saveFile.resolutionChoice = value;
        }
    }
    public static int MonitorChoice
    {
        get
        {
            return SaveFileManager.saveFile.monitorChoice;
        }
        set
        {
            SaveFileManager.saveFile.monitorChoice = value;
        }
    }
    public static int QualityLevelChoice
    {
        get
        {
            return SaveFileManager.saveFile.qualityLevel;
        }
        set
        {
            SaveFileManager.saveFile.qualityLevel = value;
        }
    }
    public static float MasterVolume
    {
        get
        {
            return SaveFileManager.saveFile.masterVolume;
        }
        set
        {
            SaveFileManager.saveFile.masterVolume = value;
        }
    }
    public static float MusicVolume
    {
        get
        {
            return SaveFileManager.saveFile.musicVolume;
        }
        set
        {
            SaveFileManager.saveFile.musicVolume = value;
        }
    }
    public static float SFXVolume
    {
        get
        {
            return SaveFileManager.saveFile.sfxVolume;
        }
        set
        {
            SaveFileManager.saveFile.sfxVolume = value;
        }
    }
    public static float XSensitivity
    {
        get
        {
            return SaveFileManager.saveFile.xSensitivity;
        }
        set
        {
            SaveFileManager.saveFile.xSensitivity = value;
        }
    }
    public static float YSensitivity
    {
        get
        {
            return SaveFileManager.saveFile.ySensitivity;
        }
        set
        {
            SaveFileManager.saveFile.ySensitivity = value;
        }
    }
    public static bool XInverted
    {
        get
        {
            return SaveFileManager.saveFile.xInverted;
        }
        set
        {
            SaveFileManager.saveFile.xInverted = value;
        }
    }
    public static bool YInverted
    {
        get
        {
            return SaveFileManager.saveFile.yInverted;
        }
        set
        {
            SaveFileManager.saveFile.yInverted = value;
        }
    }
    //TODO: Add key bindings
}
