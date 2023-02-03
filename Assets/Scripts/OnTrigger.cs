using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> OnEnemyEnter;
    [SerializeField] private UnityEvent<GameObject> OnEnemyExit;
    [SerializeField] private string _tagField;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagField))
        {
            OnEnemyEnter?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_tagField))
        {
            OnEnemyExit?.Invoke(other.gameObject);
        }
    }
}
