using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PoolManager _poolManager;
    [SerializeField] private UnityEvent OnGameStart;
    [SerializeField] private UnityEvent OnGamePause;
    [SerializeField] private UnityEvent OnGameResume;

    private void Awake()
    {
        _poolManager.CreatePools();
    }

    public void StartGame()
    {
        GameManager.Instance.GameState = GameState.PLAY;
        Time.timeScale = 1;
        OnGameStart?.Invoke();
    }

    public void PauseGame()
    {
        GameManager.Instance.GameState = GameState.PAUSE;
        Time.timeScale = 0;
    }







}
