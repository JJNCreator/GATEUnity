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
    public GameObject taskListObject;
    public GameObject taskItemPrefab;
    public GameObject gameOverPanel;
    
    void OnEnable()
    {
        //PauseMenuManager.onGamePaused += OnGamePaused;
    }
    void OnDisable()
    {
        //PauseMenuManager.onGamePaused -= OnGamePaused;
    }
    // Start is called before the first frame update
    void Start()
    {
        ToggleCursor(false);
        PopulateTaskList();
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
    public void ToggleGameOverPanel()
    {
        gameOverPanel.SetActive(true);
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
    private async UniTask ReloadLevel()
    {
        var asyncOperation = SceneManager.LoadSceneAsync(
            SceneManager.GetActiveScene().buildIndex);
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
    public void PopulateTaskList()
    {
        for(int i = 0; i < GameManager.Instance.taskItems.Length; i++)
        {
            var taskItem = GameManager.Instance.taskItems[i];
            var spawnTaskUIItem = Instantiate(taskItemPrefab);
            spawnTaskUIItem.transform.SetParent(taskListObject.transform, false);
            spawnTaskUIItem.GetComponent<TaskUIItem>().AssignValues(taskItem);
        }
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
    public void OnClickRetry()
    {
        ReloadLevel().Forget();
    }
    #endregion
}
