using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _topCamera;
   
    [SerializeField] public GameObject croshair;


    private CinemachineVirtualCamera _currentCamera;

    private void Start()
    {
        _currentCamera = _mainCamera;
        _mainCamera.enabled = true;
        _topCamera.enabled = false;
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetMainCamera();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            SetTopCamera();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnlockCursor();
        }
       
    }

    public void SetTopCamera()
    {
        _currentCamera.enabled = false;
        _currentCamera = _topCamera;
        _currentCamera.enabled = true;
        croshair.SetActive(false);

    }

    public void SetMainCamera()
    {
        _currentCamera.enabled = false;
        _currentCamera = _mainCamera;
        _currentCamera.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        croshair.SetActive(true);
    }

    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
