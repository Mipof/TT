using System.Collections;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyWaves _wave;
    [SerializeField] private PoolManager _poolManager;
    [SerializeField] private GameObject[] _waypoints;
    private int _currentWave;

    public void Spawn()
    {
        StartCoroutine(WaveSpawnRoutine());
    }

    IEnumerator WaveSpawnRoutine()
    {
        if(_currentWave < _wave._waves.Length && GameManager.Instance.GameState == GameState.PLAY)
        {
            StartCoroutine(SpawnEnemiesRoutine(_wave._waves[_currentWave]));
        }

        yield return null;
    }

    IEnumerator SpawnEnemiesRoutine(EnemyWaves.EnemyQty wave)
    {
        for (int i = 0; i < wave.Quantity; i++)
        {
            PoolManager.EnemyPool pool = _poolManager.GetPool(_wave._waves[_currentWave].EnemyType);
            GameObject enemy = pool.Pool.GetGameObjectFromPool();
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
            if (enemy.TryGetComponent(out FollowWaypoint waypoint))
            {
                waypoint.SetWaypoints(_waypoints);
            }
            yield return new WaitForSeconds(wave.TimeDelay);
        }

        _currentWave++;
        StartCoroutine(WaveSpawnRoutine());

    }
}
