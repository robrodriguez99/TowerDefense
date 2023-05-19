using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private float _xSensitivity = 20f;
    private float _ySensitivity = 20f;

    private float xRotation;
    private float yRotation;

    public Transform _orientation;
    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _xSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _ySensitivity;

        yRotation += mouseX;
        xRotation -= mouseY; // Modify xRotation with negative mouseY

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        _orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}