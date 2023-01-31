using System.Collections;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyWaves _wave;
    [SerializeField] private LevelManager _levelManager;
    private int _currentWave;

    private void Spawn()
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
            GameObject enemy = _levelManager.GetPool(_wave._waves[_currentWave].EnemyType).GetGameObjectFromPool();
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
            yield return new WaitForSeconds(wave.TimeDelay);
        }

        _currentWave++;
        StartCoroutine(WaveSpawnRoutine());

    }
}
