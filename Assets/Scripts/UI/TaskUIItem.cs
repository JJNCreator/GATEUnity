using UnityEngine;
using TMPro;

public class TaskUIItem : MonoBehaviour
{
    public TaskDataSO taskData;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Color _completedColor;

    private void OnEnable()
    {
        EventDelegates.onTaskCompleted += OnTaskCompleted;
    }

    private void OnDisable()
    {
        EventDelegates.onTaskCompleted -= OnTaskCompleted;
    }

    public void AssignValues(TaskDataSO so)
    {
        taskData = so;
        _title.text = taskData.title;
        _description.text = taskData.description;
    }
    private void OnTaskCompleted(TaskDataSO so)
    {
        if(so == taskData)
        {
            _title.fontStyle = FontStyles.Strikethrough;
            _description.fontStyle = FontStyles.Strikethrough;
            _title.color = _completedColor;
            _description.color = _completedColor;
        }
    }
}
