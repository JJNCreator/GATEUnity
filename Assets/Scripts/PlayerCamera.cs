using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraTarget;
    private float xRotation;
    private float yRotation;
    public float inputX;
    public float inputY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void LateUpdate()
    {
        xRotation += inputY;
        yRotation += inputX;

        xRotation = Mathf.Clamp(xRotation, -30, 70);

        var rotation = Quaternion.Euler(xRotation, yRotation, 0);
        cameraTarget.rotation = rotation;
    }
}
