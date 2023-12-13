using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _topCamera;
   

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
            // _currentCamera.enabled = false;
            // _currentCamera = _mainCamera;
            // _currentCamera.enabled = true;
            SetMainCamera();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            // _currentCamera.enabled = false;
            // _currentCamera = _topCamera;
            // _currentCamera.enabled = true;
            SetTopCamera();
        }
       
    }

    public void SetTopCamera()
    {
        _currentCamera.enabled = false;
        _currentCamera = _topCamera;
        _currentCamera.enabled = true;
    }

    public void SetMainCamera()
    {
        _currentCamera.enabled = false;
        _currentCamera = _mainCamera;
        _currentCamera.enabled = true;
    }
}
