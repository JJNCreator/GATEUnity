using UnityEngine;

[CreateAssetMenu(fileName = "TaskDataSO", menuName = "Task Data")]
public class TaskDataSO : ScriptableObject
{
    public string title;
    public string description;
    public TaskType type;
    public int requiredAmount;
    public enum TaskType
    {
        Eliminate,
        Gather
    }
    public bool IsCompleted(int currentAmount)
    {
        return (currentAmount >= requiredAmount);
    }
}
