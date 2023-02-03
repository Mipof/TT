using System;
using UnityEngine;

public class LookToMovement : MonoBehaviour
{
    [SerializeField][Range(0,20)][Min(1)] int _rotationSpeed = 20;
    private float _maxRadiansDelta = 1f;
    private Vector3 _previousPosition;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Vector3 currentDirection = _transform.position - _previousPosition;
        Vector3 targetDirection = Vector3.RotateTowards(_transform.forward, currentDirection, _maxRadiansDelta,
            Time.deltaTime);
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, Quaternion.LookRotation(targetDirection),
            Time.deltaTime * _rotationSpeed);
        _previousPosition = _transform.position;
    }
}
