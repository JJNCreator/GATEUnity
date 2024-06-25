using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering;

public static class SaveFileManager
{
    public static SaveFile saveFile = new();
    private static string filePath;

    public static void Save()
    {
        filePath = string.Format("{0}/ProjectVenariUnity.json", Application.persistentDataPath);

        var saveFileChanges = new SaveFile();
        saveFileChanges.vSync = saveFile.vSync;
        saveFileChanges.resolutionChoice = saveFile.resolutionChoice;
        saveFileChanges.monitorChoice = saveFile.monitorChoice;
        saveFileChanges.qualityLevel = saveFile.qualityLevel;
        saveFileChanges.masterVolume = saveFile.masterVolume;
        saveFileChanges.musicVolume = saveFile.musicVolume;
        saveFileChanges.sfxVolume = saveFile.sfxVolume;
        saveFileChanges.xSensitivity = saveFile.xSensitivity;
        saveFileChanges.ySensitivity = saveFile.ySensitivity;
        saveFileChanges.xInverted = saveFile.xInverted;
        saveFileChanges.yInverted = saveFile.yInverted;
        //TODO: Add key kindings
        string writeToFile = JsonUtility.ToJson(saveFileChanges, true);
        File.WriteAllText(filePath, writeToFile);
    }
    public static void Load()
    {
        filePath = string.Format("{0}/ProjectVenariUnity.json", Application.persistentDataPath);

        if (File.Exists(filePath))
        {
            var loadFile = File.ReadAllText(filePath);

            try
            {
                saveFile = JsonUtility.FromJson<SaveFile>(loadFile);
            }
            catch
            {
                Debug.LogWarning("SaveFileManager:Load() - Save file appears to be malformed.");
            }
        }
    }
}

[System.Serializable]
public class SaveFile
{
    public bool vSync;
    public int resolutionChoice;
    public int monitorChoice;
    public int qualityLevel;
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
    public float xSensitivity;
    public float ySensitivity;
    public bool xInverted;
    public bool yInverted;
    //TODO: add key bindings
}
