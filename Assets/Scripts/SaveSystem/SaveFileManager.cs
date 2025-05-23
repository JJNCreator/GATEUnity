using UnityEngine;
using System.IO;

public static class SaveFileManager
{
    public static SaveFile saveFile = new();
    public static bool alreadyLoadedFileForSession;
    public static bool appliedSettingsForSession;
    private static string filePath;

    public static void Save()
    {
        filePath = string.Format("{0}/GATEUnity.json", Application.persistentDataPath);

        var saveFileChanges = new SaveFile();
        saveFileChanges.vSync = saveFile.vSync;
        saveFileChanges.resolutionChoice = saveFile.resolutionChoice;
        saveFileChanges.fullscreen = saveFile.fullscreen;
        saveFileChanges.qualityLevel = saveFile.qualityLevel;
        saveFileChanges.masterVolume = saveFile.masterVolume;
        saveFileChanges.musicVolume = saveFile.musicVolume;
        saveFileChanges.sfxVolume = saveFile.sfxVolume;
        saveFileChanges.xSensitivity = saveFile.xSensitivity;
        saveFileChanges.ySensitivity = saveFile.ySensitivity;
        saveFileChanges.xInverted = saveFile.xInverted;
        saveFileChanges.yInverted = saveFile.yInverted;
        saveFileChanges.keyBindings = saveFile.keyBindings;
        saveFileChanges.motionBlur = saveFile.motionBlur;
        string writeToFile = JsonUtility.ToJson(saveFileChanges, true);
        File.WriteAllText(filePath, writeToFile);
    }
    public static void Load()
    {
        if (alreadyLoadedFileForSession)
            return;

        filePath = string.Format("{0}/GATEUnity.json", Application.persistentDataPath);

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
        else
        {
            saveFile.vSync = false;
            saveFile.resolutionChoice = 0;
            saveFile.fullscreen = false;
            saveFile.qualityLevel = 0;
            saveFile.masterVolume = 1f;
            saveFile.musicVolume = 1f;
            saveFile.sfxVolume = 1f;
            saveFile.xSensitivity = 30f;
            saveFile.ySensitivity = 30f;
            saveFile.xInverted = false;
            saveFile.yInverted = false;
            saveFile.keyBindings = string.Empty;
            saveFile.motionBlur = true;

            Save();
        }
        alreadyLoadedFileForSession = true;
    }
}

[System.Serializable]
public class SaveFile
{
    public bool vSync;
    public int resolutionChoice;
    public bool fullscreen;
    public int qualityLevel;
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
    public float xSensitivity;
    public float ySensitivity;
    public bool xInverted;
    public bool yInverted;
    public string keyBindings;
    public bool motionBlur;
}
