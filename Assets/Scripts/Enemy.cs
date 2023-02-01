using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(FollowWaypoint))]
[RequireComponent(typeof(GOToPool))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _data;
    [SerializeField] private UnityEvent OnBackToPool;

    private Health _health;
    private FollowWaypoint _waypoint;
    

    private void OnEnable()
    {
        _health = GetComponent<Health>();
        _waypoint = GetComponent<FollowWaypoint>();
        
        _health.SetMaxHealth(_data._enemy.Health);
        _health.GetShield(_data._enemy.Shield);
        _health.HealToMax();
        
        _waypoint.SetSpeed(_data._enemy.Speed);
    }

    private void OnDisable()
    {
        OnBackToPool?.Invoke();
    }

    public void SetWaypoint(GameObject[] waypoint)
    {
        _waypoint.SetWaypoints(waypoint);
    }
}
