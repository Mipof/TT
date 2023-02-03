using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> OnEnemyEnter;
    [SerializeField] private UnityEvent<Vector3> OnEnemyEnterPosition;
    [SerializeField] private UnityEvent<GameObject> OnEnemyExit;
    [SerializeField] private string _tagField;
    [SerializeField] private float _delay;
    private bool _ready = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagField) && _ready)
        {
            OnEnemyEnter?.Invoke(other.gameObject);
            OnEnemyEnterPosition?.Invoke(other.transform.position);
            _ready = false;
            StartCoroutine(DelayRoutine(_delay));
        }
    }

    IEnumerator DelayRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        _ready = true;
    }

    public void SetNewDelay(float delay)
    {
        _delay = delay;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_tagField))
        {
            OnEnemyExit?.Invoke(other.gameObject);
        }
    }
}