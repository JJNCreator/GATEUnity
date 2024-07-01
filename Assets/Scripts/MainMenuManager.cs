using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public enum MenuState
    {
        Main = 0,
        Extras = 1,
        SettingsGraphics = 2,
        SettingsAudio = 3,
        SettingsControls = 4
    }
    [SerializeField] private AudioMixerGroup _masterGroup;
    [SerializeField] private AudioMixerGroup _musicGroup;
    [SerializeField] private AudioMixerGroup _sfxGroup;
    [SerializeField] private MenuState _menuState;
    [SerializeField] private GameObject _mainButtonsObject;
    [SerializeField] private GameObject _extrasObject;
    [SerializeField] private GameObject _settingsObject;
    [SerializeField] private GameObject _graphicsSettingsObject;
    [SerializeField] private GameObject _audioSettingsObject;
    [SerializeField] private GameObject _controlsSettingsObject;
    [SerializeField] private GameObject _mouseKeyboardBindings;
    [SerializeField] private GameObject _controllerBindings;

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Dropdown _monitorDropdown;
    [SerializeField] private TMP_Dropdown _qualityLevelDropdown;
    public MenuState CurrentMenuState
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
    [SerializeField] private TextMeshProUGUI _versionText;
    // Start is called before the first frame update
    void Start()
    {
        _versionText.text = Application.version;
        SaveFileManager.Load();

        SetResolutionOptions();
        SetMonitorOptions();
        SetQualityOptions();

        _masterGroup.audioMixer.SetFloat("MasterVolume", GameSettings.MasterVolume);
        _musicGroup.audioMixer.SetFloat("MusicVolume", GameSettings.MusicVolume);
        _sfxGroup.audioMixer.SetFloat("SFXVolume", GameSettings.SFXVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMenuStateChanged(MenuState newState)
    {
        switch(newState)
        {
            case MenuState.Main:
                ToggleMenus(true, false, false, false, false);
                break;
            case MenuState.Extras:
                ToggleMenus(false, true, false, false, false);
                break;
            case MenuState.SettingsGraphics:
                ToggleMenus(false, false, true, false, false);
                break;
            case MenuState.SettingsAudio:
                ToggleMenus(false, false, false, true, false);
                break;
            case MenuState.SettingsControls:
                ToggleMenus(false, false, false, false, true);
                break;
        }
    }

    private void ToggleMenus(bool main, bool extras, bool graphics, bool audio, bool controls)
    {
        _mainButtonsObject.SetActive(main);
        _extrasObject.SetActive(extras);
        _settingsObject.SetActive(graphics || audio || controls);
        _graphicsSettingsObject.SetActive(graphics);
        _audioSettingsObject.SetActive(audio);
        _controlsSettingsObject.SetActive(controls);
    }

    private void SetResolutionOptions()
    {
        _resolutionDropdown.ClearOptions();
        var getScreenResolutions = Screen.resolutions;
        var optionsToAdd = new List<TMPro.TMP_Dropdown.OptionData>();
        foreach( var sRes in getScreenResolutions)
        {
            var option = new TMPro.TMP_Dropdown.OptionData();
            option.text = sRes.ToString();
            optionsToAdd.Add(option);
        }
        _resolutionDropdown.AddOptions(optionsToAdd);
    }
    private void SetMonitorOptions()
    {
        _monitorDropdown.ClearOptions();
        var getMonitorResolutions = Display.displays;
        var optionsToAdd = new List<TMPro.TMP_Dropdown.OptionData>();
        foreach (var monitor in getMonitorResolutions)
        {
            var option = new TMPro.TMP_Dropdown.OptionData();
            option.text = monitor.ToString();
            optionsToAdd.Add(option);
        }
        _monitorDropdown.AddOptions(optionsToAdd);
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

    #region editor-bound
    public async UniTask PlayGame()
    {
        var loadScene = SceneManager.LoadSceneAsync(1);
        while(!loadScene.isDone)
        {
            await UniTask.Yield();
        }
    }
    public void OnPlayGameClicked()
    {
        PlayGame().Forget();
    }

    public void OnMainMenuClicked()
    {
        SaveFileManager.Save();
        CurrentMenuState = MenuState.Main;
    }
    public void OnExtrasClicked()
    {
        CurrentMenuState = MenuState.Extras;
    }
    public void OnGraphicsSettingsClicked()
    {
        CurrentMenuState = MenuState.SettingsGraphics;
    }
    public void OnAudioSettingsClicked()
    {
        CurrentMenuState = MenuState.SettingsAudio;
    }
    public void OnControlSettingsClicked()
    {
        CurrentMenuState = MenuState.SettingsControls;
    }

    public void OnFeedbackClicked()
    {
        Application.OpenURL("https://forms.gle/kDkkPbHjXCggZxiM6");
    }

    public void OnQuitGameClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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
        Screen.SetResolution(int.Parse(selectedOptionSplit[0]), int.Parse(selectedOptionSplit[1]), false);
    }
    public void SetMonitorChoice(int i)
    {
        GameSettings.MonitorChoice = i;
        Display.displays[GameSettings.MonitorChoice].Activate();
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

    #endregion
}
