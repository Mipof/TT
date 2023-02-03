using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float _damage;


    public void SendDamage(GameObject target)
    {
        if (target.TryGetComponent(out Health health))
        {
            health.GetDamage(_damage);
        }
    }

    public void SetNewDamage(TurretData data)
    {
        _damage = data._turret.DamagePerHit;
    }
}