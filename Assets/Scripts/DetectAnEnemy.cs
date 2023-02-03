using UnityEngine;
using UnityEngine.Events;

public class DetectAnEnemy : MonoBehaviour
{

    [SerializeField] private UnityEvent<Transform> OnDetectEnemy;
    [SerializeField] private UnityEvent OnLoseEnemy;

    [SerializeField] [Range(0f, 20f)] [Min(0f)]
    private float _range;

    private Transform _enemyDetected;

    private void OnTriggerStay(Collider other)
    {
        print(other.transform.tag);
        if (!_enemyDetected && other.CompareTag("Enemy"))
        {
            _enemyDetected = other.transform;
            OnDetectEnemy?.Invoke(_enemyDetected);
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);
        Debug.DrawLine(transform.position,transform.position + new Vector3(_range,0f,0f),Color.green);
        if (_enemyDetected)
        {
            float distance = Vector3.Distance(transform.position, _enemyDetected.position);
            if (distance > _range)
            {
                _enemyDetected = null;
                OnLoseEnemy?.Invoke();
            }
        }
        else
        {
            _enemyDetected = null;
        }
    }
}
