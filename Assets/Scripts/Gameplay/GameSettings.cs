public static class GameSettings
{
    public static bool VSync
    {
        get
        {
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.vSync : false;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.resolutionChoice : 0;
        }
        set
        {
            SaveFileManager.saveFile.resolutionChoice = value;
        }
    }
    public static bool Fullscreen
    {
        get
        {
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.fullscreen : false;
        }
        set
        {
            SaveFileManager.saveFile.fullscreen = value;
        }
    }
    public static int QualityLevelChoice
    {
        get
        {
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.qualityLevel : 0;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.masterVolume : 1f;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.musicVolume : 1f;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.sfxVolume : 1f;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.xSensitivity : 5f;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.ySensitivity : 5f;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.xInverted : false;
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
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.yInverted : false;
        }
        set
        {
            SaveFileManager.saveFile.yInverted = value;
        }
    }
    public static bool MotionBlur
    {
        get
        {
            return (SaveFileManager.saveFile != null) ? SaveFileManager.saveFile.motionBlur : true;
        }
        set
        {
            SaveFileManager.saveFile.motionBlur = value;
        }
    }
}
