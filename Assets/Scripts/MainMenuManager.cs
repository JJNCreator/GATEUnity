using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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
    [SerializeField] private MenuState _menuState;
    [SerializeField] private GameObject _mainButtonsObject;
    [SerializeField] private GameObject _extrasObject;
    [SerializeField] private GameObject _settingsObject;
    [SerializeField] private GameObject _graphicsSettingsObject;
    [SerializeField] private GameObject _audioSettingsObject;
    [SerializeField] private GameObject _controlsSettingsObject;
    [SerializeField] private GameObject _mouseKeyboardBindings;
    [SerializeField] private GameObject _controllerBindings;
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
    }
    public void SetResolutionChoice(int i)
    {
        GameSettings.ResolutionChoice = i;
    }
    public void SetMonitorChoice(int i)
    {
        GameSettings.MonitorChoice = i;
    }
    public void SetQualityLevel(int i)
    {
        GameSettings.QualityLevelChoice = i;
    }
    public void SetMasterVolume(float f)
    {
        GameSettings.MasterVolume = f;
    }
    public void SetMusicVolume(float f)
    {
        GameSettings.MusicVolume = f;
    }
    public void SetSFXVolume(float f)
    {
        GameSettings.SFXVolume = f;
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
