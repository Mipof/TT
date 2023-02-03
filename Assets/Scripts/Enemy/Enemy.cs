using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(FollowWaypoint))]
[RequireComponent(typeof(GOToPool))]
[RequireComponent(typeof(Damage))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _data;
    [FormerlySerializedAs("SendCurrency")]
    [Space(20)] 
    [SerializeField] private UnityEvent<int> OnDeath;
    [SerializeField] private UnityEvent OnBackToPool;

    private Health _health;
    private FollowWaypoint _waypoint;
    private Damage _damage;
   
    private void OnEnable()
    {
        _health = GetComponent<Health>();
        _waypoint = GetComponent<FollowWaypoint>();
        _damage = GetComponent<Damage>();
        
        _health.SetMaxHealth(_data._enemy.Health);
        _health.GetShield(_data._enemy.Shield);
        _health.HealToMax();
        
        _waypoint.SetSpeed(_data._enemy.Speed);
        
        _damage.SetNewDamage(_data._enemy.DamagePerHit);
        
    }

    private void OnDisable()
    {
        OnBackToPool?.Invoke();
    }

    public void SetWaypoint(GameObject[] waypoint)
    {
        _waypoint.SetWaypoints(waypoint);
    }

    public void DisableGO()
    {
        OnDeath?.Invoke(_data._enemy.CurrencyOnDeath);
        transform.gameObject.SetActive(false);
    }
}
