using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] [Min(0f)] [Range(0f, 10f)]
    private float _damage;


    public void SendDamage(GameObject target)
    {
        if (target.TryGetComponent(out Health health))
        {
            health.GetDamage(_damage);
        }
    }
}
