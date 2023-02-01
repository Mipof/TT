using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _levelBrain;
    [SerializeField] private PoolManager _poolManager;
    [SerializeField] private UnityEvent OnGameStart;
    [SerializeField] private UnityEvent OnGamePause;
    [SerializeField] private UnityEvent OnGameResume;
    

    private void Awake()
    {
        _poolManager.CreatePools();
        GameManager.Instance.Brain = _levelBrain;
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
