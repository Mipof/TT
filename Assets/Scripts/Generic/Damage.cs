using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float _damage;


    public void SendDamage(GameObject target)
    {
        print("Damage");
        if (target.TryGetComponent(out Health health))
        {
            health.GetDamage(_damage);
        }
    }

    public void SetNewDamage(int damage)
    {
        _damage = damage;
    }
}