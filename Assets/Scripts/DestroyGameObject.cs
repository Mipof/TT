using UnityEngine;
using UnityEngine.Events;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _timeBeforeDestroy;
    [SerializeField] private UnityEvent OnDestroy;

    public void DestroyGO()
    {
        Destroy(gameObject,_timeBeforeDestroy);
    }
}
