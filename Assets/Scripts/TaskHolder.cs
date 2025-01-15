using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCurrentTaskProgressUpdated(int value)
    {
        if(taskData.IsCompleted(value))
        {
            EventDelegates.ExecuteTaskCompletedEvent(taskData);
        }
    }
}
