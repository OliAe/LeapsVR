using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    public string mouseXInputName, mouseYInputName;
    public float mouseSensitivty;
    public int mouseSensitivtyX;

    public Transform playerBody;

    public float xAxisClamp;

    public int axis270 = 270;
    public int axis90 = 90;

    public void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        CameraRotation();
    }

    public void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivtyX * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivty * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(axis270);
        }

        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseX = 0.0f;
            ClampXAxisRotationToValue(axis90);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}

