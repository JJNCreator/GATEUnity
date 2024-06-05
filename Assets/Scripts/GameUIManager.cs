using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    private static GameUIManager _instance;
    public static GameUIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<GameUIManager>();
            return _instance;
        }
    }
    public GameObject HUDObject;
    public GameObject pauseMenuObject;
    
    void OnEnable()
    {
        PauseMenuManager.onGamePaused += OnGamePaused;
    }
    void OnDisable()
    {
        PauseMenuManager.onGamePaused -= OnGamePaused;
    }
    // Start is called before the first frame update
    void Start()
    {
        ToggleCursor(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGamePaused(bool paused)
    {
        HUDObject.SetActive(!paused);
        pauseMenuObject.SetActive(paused);
        ToggleCursor(paused);
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
    public void OnClickPauseState()
    {
        PauseMenuManager.Instance.Paused = !PauseMenuManager.Instance.Paused;
    }
    public void OnClickOptions()
    {
        //TODO: Work on this
    }
    public void OnClickQuit()
    {
        AudioListener.pause = !AudioListener.pause;
        LoadMainMenu().Forget();
    }
    #endregion
}
