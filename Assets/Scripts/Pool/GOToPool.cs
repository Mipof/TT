using UnityEngine;

public class GOToPool : MonoBehaviour
{
    [SerializeField] ObjectPool ObjectPool;

    private void OnDisable()
    {
        ObjectPool.ReturnGameObjectToPool(gameObject);
    }

    public void SetObjecPool(ObjectPool pool)
    {
        ObjectPool = pool;
    }
}
