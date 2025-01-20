using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ScrollRectControllerInput : MonoBehaviour
{
    private ScrollRect _scrollRect;
    private PlayerInput _playerInput;
    private InputAction _scrollWheelAction;
    private Vector2 ScrollInput { get; set; }

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _playerInput = FindFirstObjectByType<PlayerInput>();
        _scrollWheelAction = _playerInput.actions["ScrollWheel"];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollInput = _scrollWheelAction.ReadValue<Vector2>();
        _scrollRect.verticalNormalizedPosition += ScrollInput.y * Time.unscaledDeltaTime;
    }
}
