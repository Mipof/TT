using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> OnEnemyEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnEnemyEnter?.Invoke(other.gameObject);
        }
    }
}
