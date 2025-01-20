using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDelegates
{
    public delegate void OnGameOver();
    public static event OnGameOver onGameOver;

    public delegate void OnTaskCompleted(TaskDataSO so);
    public static event OnTaskCompleted onTaskCompleted;

    public delegate void OnSettingsLoaded();
    public static event OnSettingsLoaded onSettingsLoaded;

    public delegate void OnGamePaused(bool b);
    public static event OnGamePaused onGamePaused;

    public static void ExecuteGameOverEvent()
    {
        onGameOver?.Invoke();
    }
    public static void ExecuteTaskCompletedEvent(TaskDataSO so)
    {
        onTaskCompleted?.Invoke(so);
    }
    public static void ExecuteSettingsLoadedEvent()
    {
        onSettingsLoaded?.Invoke();
    }
    public static void ExecuteGamePausedEvent(bool b)
    {
        onGamePaused?.Invoke(b);
    }

}
