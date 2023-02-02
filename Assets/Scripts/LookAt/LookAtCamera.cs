using System;
using Cinemachine;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _brain;

    private void Awake()
    {
        if (!_brain)
        {
            _brain = GameManager.Instance.Brain;
        }
    }

    private void Update()
    {
        if (!_brain) return;
        Vector3 cameraPosition = _brain.OutputCamera.transform.position;
        Vector3 lookingAt = new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z);
        transform.LookAt(lookingAt);
    }
}
