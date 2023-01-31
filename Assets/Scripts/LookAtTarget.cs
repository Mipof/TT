using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        if(_target == null) return;

        Vector3 direction = _target.position - transform.position;
        
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void LoseTarget()
    {
        _target = null;
    }
}
