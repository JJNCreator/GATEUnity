using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public float inputX;
    public float inputY;
    public float mouseSensitivityX = 3f;
    public float mouseSensitivityY = 3f;
    public float distanceFromTarget = 3f;
    public bool inverted = false;
    private float rotationY;
    private float rotationX;
    private Vector3 CurrentRotation;
    private Vector3 SmoothVelocity;
    private float SmoothTime = 0.2f;
    private Transform _transformCache;
    private void Awake()
    {
        _transformCache = transform;
    }
    private void LateUpdate()
    {
        var lookVector = new Vector2(inputX, inputY).normalized;
        float mouseX = lookVector.x * mouseSensitivityX;
        float mouseY = lookVector.y * mouseSensitivityY;
        rotationY += mouseX;
        rotationX += (inverted) ? mouseY : mouseY * -1f;
        rotationX = Mathf.Clamp(rotationX, -40f, 40f);
        var nextRotation = new Vector3(rotationX, rotationY);
        CurrentRotation = Vector3.SmoothDamp(CurrentRotation, nextRotation, ref SmoothVelocity, SmoothTime);
        _transformCache.eulerAngles = CurrentRotation;
        if (target != null)
        {
            _transformCache.position = target.position - _transformCache.forward * distanceFromTarget;
        }
    }
}
