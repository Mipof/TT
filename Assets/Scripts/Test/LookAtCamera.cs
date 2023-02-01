using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _brain;
    [SerializeField] private CameraControl _control;
    private void Update()
    {
        transform.LookAt(_brain.OutputCamera.transform);
    }
}
