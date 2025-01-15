using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDelegates
{
    public delegate void OnGameOver();
    public static event OnGameOver onGameOver;

    public delegate void OnTaskCompleted(TaskDataSO so);
    public static event OnTaskCompleted onTaskCompleted;

    public static void ExecuteGameOverEvent()
    {
        onGameOver?.Invoke();
    }
    public static void ExecuteTaskCompletedEvent(TaskDataSO so)
    {
        onTaskCompleted?.Invoke(so);
    }
}
