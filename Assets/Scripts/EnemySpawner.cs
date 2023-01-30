using Unity.Mathematics;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _waypointList;

    [ContextMenu("SpwanEnemy")]
    public void SpawnAnEnemy()
    {
        GameObject enemy = Instantiate(_enemy, transform.localPosition, quaternion.identity);
        if (enemy.TryGetComponent(out FollowWaypoint waypoint))
        {
            waypoint.SetWaypoints(_waypointList);
        }
    }
}
