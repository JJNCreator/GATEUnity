using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using static MainMenuManager;
using UnityEngine.Audio;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    public enum PauseMenuState
    {
        Main = 0,
        SettingsGraphics = 1,
        SettingsAudio = 2,
        SettingsControls = 3,
        None = 4
    }

    public delegate void OnGamePaused(bool b);
    public static event OnGamePaused onGamePaused;

    [SerializeField] private AudioMixerGroup _masterGroup;
    [SerializeField] private AudioMixerGroup _musicGroup;
    [SerializeField] private AudioMixerGroup _sfxGroup;
    [SerializeField] private PauseMenuState _menuState;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _mainButtonsObject;
    [SerializeField] private GameObject _settingsObject;
    [SerializeField] private GameObject _graphicsSettingsObject;
    [SerializeField] private GameObject _audioSettingsObject;
    [SerializeField] private GameObject _controlsSettingsObject;
    [SerializeField] private GameObject _mouseKeyboardBindings;
    [SerializeField] private GameObject _controllerBindings;

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Dropdown _qualityLevelDropdown;
    [SerializeField] private InputActionAsset _inputActions;
    public PauseMenuState CurrentMenuState
    {
        get
        {
            return _menuState;
        }
        set
        {
            _menuState = value;
            OnMenuStateChanged(_menuState);
        }
    }

    private static PauseMenuManager _instance;
    public static PauseMenuManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindFirstObjectByType<PauseMenuManager>();
            return _instance;
        }
    }
    private bool _paused = false;
    public bool Paused
    {
        get
        {
            return _paused;
        }
        set
        {
            _paused = value;
            OnPauseChanged(_paused);
        }
    }

    private void Start()
    {
        SetResolutionOptions();
        SetQualityOptions();

        _masterGroup.audioMixer.SetFloat("MasterVolume", GameSettings.MasterVolume);
        _musicGroup.audioMixer.SetFloat("MusicVolume", GameSettings.MusicVolume);
        _sfxGroup.audioMixer.SetFloat("SFXVolume", GameSettings.SFXVolume);
    }

    void Update()
    {
        if(UserInput.Instance.PausedPressed)
        {
            if(!Paused)
            {
                Paused = true;
            }
            else
            {
                Paused = false;
            }
        }
    }

    private void OnPauseChanged(bool paused)
    {
        onGamePaused?.Invoke(paused);
        if(paused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            CurrentMenuState = PauseMenuState.Main;
            EventSystem.current.firstSelectedGameObject = _mainButtonsObject.transform.GetChild(0).gameObject;
            _background.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            CurrentMenuState = PauseMenuState.None;
            _background.SetActive(false);
        }
        ToggleCursor(paused);
    }
    private void OnMenuStateChanged(PauseMenuState newState)
    {
        switch (newState)
        {
            case PauseMenuState.Main:
                ToggleMenus(true, false, false, false);
                break;
            case PauseMenuState.SettingsGraphics:
                ToggleMenus(false, true, false, false);
                break;
            case PauseMenuState.SettingsAudio:
                ToggleMenus(false, false, true, false);
                break;
            case PauseMenuState.SettingsControls:
                ToggleMenus(false, false, false, true);
                break;
            case PauseMenuState.None:
                ToggleMenus(false, false, false, false);
                break;
        }
    }
    private void SaveKeyBindings()
    {
        var rebinds = _inputActions.SaveBindingOverridesAsJson();
        SaveFileManager.saveFile.keyBindings = rebinds;
    }
    private void LoadKeyBindings()
    {
        var rebinds = SaveFileManager.saveFile.keyBindings;
        if (!string.IsNullOrEmpty(rebinds))
            _inputActions.LoadBindingOverridesFromJson(rebinds);
    }
    private void ToggleMenus(bool main, bool graphics, bool audio, bool controls)
    {
        _mainButtonsObject.SetActive(main);
        _settingsObject.SetActive(graphics || audio || controls);
        _graphicsSettingsObject.SetActive(graphics);
        _audioSettingsObject.SetActive(audio);
        _controlsSettingsObject.SetActive(controls);
        if(controls)
        {
            LoadKeyBindings();
        }
    }
    private void SetResolutionOptions()
    {
        _resolutionDropdown.ClearOptions();
        var getScreenResolutions = Screen.resolutions;
        var optionsToAdd = new List<TMPro.TMP_Dropdown.OptionData>();
        foreach (var sRes in getScreenResolutions)
        {
            var option = new TMPro.TMP_Dropdown.OptionData();
            option.text = sRes.ToString();
            optionsToAdd.Add(option);
        }
        _resolutionDropdown.AddOptions(optionsToAdd);
    }
    private void SetQualityOptions()
    {
        _qualityLevelDropdown.ClearOptions();
        var getQualityOptions = QualitySettings.names;
        var optionsToAdd = new List<TMPro.TMP_Dropdown.OptionData>();
        foreach (var quality in getQualityOptions)
        {
            var option = new TMPro.TMP_Dropdown.OptionData();
            option.text = quality.ToString();
            optionsToAdd.Add(option);
        }
        _qualityLevelDropdown.AddOptions(optionsToAdd);
    }

    private async UniTask LoadMainMenu()
    {
        var asyncOperation = SceneManager.LoadSceneAsync("MainMenu");
        PauseMenuManager.Instance.Paused = false;
        ToggleCursor(true);
        while (!asyncOperation.isDone)
        {
            await UniTask.Yield();
        }
    }
    public void ToggleCursor(bool on)
    {
        Cursor.visible = on;
    }

    #region editor-bound
    public void OnMainMenuClicked()
    {
        SaveKeyBindings();
        SaveFileManager.Save();
        CurrentMenuState = PauseMenuState.Main;
    }
    public void OnGraphicsSettingsClicked()
    {
        CurrentMenuState = PauseMenuState.SettingsGraphics;
    }
    public void OnAudioSettingsClicked()
    {
        CurrentMenuState = PauseMenuState.SettingsAudio;
    }
    public void OnControlSettingsClicked()
    {
        CurrentMenuState = PauseMenuState.SettingsControls;
    }
    public void SetVSync(bool b)
    {
        GameSettings.VSync = b;
        QualitySettings.vSyncCount = (GameSettings.VSync) ? 1 : 0;
    }
    public void SetResolutionChoice(int i)
    {
        GameSettings.ResolutionChoice = i;
        var selectedOption = _resolutionDropdown.options[i].text;
        var selectedOptionSplit = selectedOption.Split(new string[]
        {
            " x ",
            " @ "
        }, System.StringSplitOptions.None);
        Screen.SetResolution(int.Parse(selectedOptionSplit[0]), int.Parse(selectedOptionSplit[1]), GameSettings.Fullscreen);
    }
    public void SetFullscreen(bool b)
    {
        GameSettings.Fullscreen = b;
        Screen.SetResolution(Screen.currentResolution.width,
           Screen.currentResolution.height,
           GameSettings.Fullscreen);
    }
    public void SetQualityLevel(int i)
    {
        GameSettings.QualityLevelChoice = i;
        QualitySettings.SetQualityLevel(GameSettings.QualityLevelChoice);
    }
    public void SetMasterVolume(float f)
    {
        GameSettings.MasterVolume = f;
        _masterGroup.audioMixer.SetFloat("MasterVolume", GameSettings.MasterVolume);
    }
    public void SetMusicVolume(float f)
    {
        GameSettings.MusicVolume = f;
        _musicGroup.audioMixer.SetFloat("MusicVolume", GameSettings.MusicVolume);
    }
    public void SetSFXVolume(float f)
    {
        GameSettings.SFXVolume = f;
        _sfxGroup.audioMixer.SetFloat("SFXVolume", GameSettings.SFXVolume);
    }
    public void SetXSensitivity(float f)
    {
        GameSettings.XSensitivity = f;
    }
    public void SetYSensitivity(float f)
    {
        GameSettings.YSensitivity = f;
    }
    public void SetXInverted(bool b)
    {
        GameSettings.XInverted = b;
    }
    public void SetYInverted(bool b)
    {
        GameSettings.YInverted = b;
    }
    public void ChangeBindingType(bool controller)
    {
        _mouseKeyboardBindings.SetActive(!controller);
        _controllerBindings.SetActive(controller);
    }
    public void SetMotionBlur(bool b)
    {
        GameSettings.MotionBlur = b;
    }
    public void OnClickQuit()
    {
        AudioListener.pause = !AudioListener.pause;
        LoadMainMenu().Forget();
    }
    #endregion
}
