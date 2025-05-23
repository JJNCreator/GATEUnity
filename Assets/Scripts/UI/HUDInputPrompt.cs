using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HUDInputPrompt : MonoBehaviour
{
    [SerializeField] private Image _promptIcon;
    [SerializeField] private string _inputActionName;
    [SerializeField] private InputIconSO _inputIcons;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.onControlsChanged += OnInputDeviceChanged;
    }

    private void OnDisable()
    {
        _playerInput.onControlsChanged -= OnInputDeviceChanged;
    }

    public void OnInputDeviceChanged(PlayerInput action)
    {
        bool controller = action.devices[0].name == "XInputControllerWindows" ||
            action.devices[0].name == "SwitchProControllerHID" ||
            action.devices[0].name == "DualShock4GamepadHID" ||
            action.devices[0].name == "DualShock3GamepadHID" ||
            action.devices[0].name == "DualSenseGamepadHID";
        SwitchBetweenInputDevices(controller, action.devices[0].layout);
    }
    private void SwitchBetweenInputDevices(bool isController, string deviceLayoutName)
    {
        var action = _playerInput.actions.FindAction(_inputActionName);
        var mkIcons = _inputIcons.mkIcons;
        var gamepadIcons = default(GamepadIcons);
        if(InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "DualShockGamepad"))
        {
            gamepadIcons = _inputIcons.dsIcons;
        }
        else if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "SwitchProControllerHID"))
        {
            gamepadIcons = _inputIcons.nSwitchIcons;
        }
        else if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Gamepad"))
        {
            gamepadIcons = _inputIcons.xboxIcons;
        }
        if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Keyboard"))
        {
            mkIcons = _inputIcons.mkIcons;
        }
        else if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Mouse"))
        {
            mkIcons = _inputIcons.mkIcons;
        }
        var actionPath = action.controls[0].path;
        actionPath = actionPath.Replace("/Keyboard/", "");
        actionPath = actionPath.Replace("/Mouse/", "");
        actionPath = actionPath.Replace("/XInputControllerWindows/", "");
        actionPath = actionPath.Replace("/SwitchProControllerHID/", "");
        actionPath = actionPath.Replace("/DualShock4GamepadHID/", "");
        actionPath = actionPath.Replace("/DualShock3GamepadHID/", "");
        actionPath = actionPath.Replace("/DualSenseGamepadHID/", "");

        if (isController)
        {
            _promptIcon.sprite = gamepadIcons.GetSprite(actionPath);
        }
        else
        {
            _promptIcon.sprite = mkIcons.GetSprite(actionPath);
        }
    }
}
