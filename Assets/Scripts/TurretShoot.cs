using System;
using System.Collections;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private float _timePerShoot;
    [SerializeField] private float _damage;
    private bool canShoot = true;
    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void LoseTarget()
    {
        _target = null;
    }

    private void Update()
    {
        if(canShoot) Shoot();
    }

    private void Shoot()
    {
        if (_target)
        {
            if (_target.TryGetComponent(out Health health))
            {
                health.GetDamage(_damage);
                StartCoroutine(WeaponCooldownRoutine());
                canShoot = false;
            }
        }
    }

    IEnumerator WeaponCooldownRoutine()
    {
        yield return new WaitForSeconds(_timePerShoot);
        canShoot = true;
    }
}
