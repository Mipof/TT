using System;
using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _brain;
    [SerializeField] private CinemachineVirtualCamera[] _listCamera;
    private CinemachineVirtualCamera _activeCamera;
    [SerializeField] private int _cameraIndex = 0;

    private void Awake()
    {
        _activeCamera = _listCamera[0];
    }
    
    public CinemachineVirtualCamera GetActiveCamera()
    {
        return _activeCamera;
    }

    public void IncreaseCam()
    {
        _activeCamera.Priority = 0;
        _cameraIndex++;
        if (_cameraIndex >= _listCamera.Length)
        {
            _cameraIndex = 0;
        }

        _activeCamera = _listCamera[_cameraIndex];
        UpdateCamera();
        _activeCamera.Priority = 1;
    }

    public void DecreaseCam()
    {
        _activeCamera.Priority = 0;
        _cameraIndex--;
        if (_cameraIndex < 0)
        {
            _cameraIndex = _listCamera.Length - 1;
        }
        _activeCamera = _listCamera[_cameraIndex];
        UpdateCamera();
        _activeCamera.Priority = 1;
    }

    private void UpdateCamera()
    {
        if (_activeCamera.transform.TryGetComponent(out CameraProperties properties))
        {
            GameManager.Instance.ActualCamera = properties.GetCameraEnum();
        }
        else
        {
            throw new Exception("Camera " + _activeCamera.transform.name + "dont contain an cameraProperties script");
        }
    }
}
