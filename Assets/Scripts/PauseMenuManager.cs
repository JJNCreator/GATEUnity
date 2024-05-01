using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public delegate void OnGamePaused(bool b);
    public static event OnGamePaused onGamePaused;

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
    private void OnPauseChanged(bool paused)
    {
        onGamePaused?.Invoke(paused);
        if(paused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }
}
