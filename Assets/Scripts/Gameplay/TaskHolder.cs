using UnityEngine;
public class TaskHolder : MonoBehaviour
{
    public TaskDataSO taskData;
    private int _currentTaskProgress;
    public int CurrentTaskProgress
    {
        get
        {
            return _currentTaskProgress;
        }
        set
        {
            _currentTaskProgress = value;
            OnCurrentTaskProgressUpdated(_currentTaskProgress);
        }
    }
    private void OnCurrentTaskProgressUpdated(int value)
    {
        if(taskData.IsCompleted(value))
        {
            EventDelegates.ExecuteTaskCompletedEvent(taskData);
        }
    }
}
