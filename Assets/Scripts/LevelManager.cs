using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _levelBrain;
    [SerializeField] private PoolManager _poolManager;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private ResourceManager _resourceManager;
    [Space(40)] [SerializeField] private UnityEvent OnGameStart;
    [SerializeField] private UnityEvent OnGamePause;
    [SerializeField] private UnityEvent OnGameResume;
    [SerializeField] private GameObject _tree;


    private void Awake()
    {
        _poolManager.CreatePools();
        _resourceManager.AddCurrency(_levelData._level.InitialCurrency);
        _tree.GetComponent<Health>().SetMaxHealth(_levelData._level.TreeHealth);
        GameManager.Instance.Brain = _levelBrain;
        GameManager.Instance.LevelManager = this;
    }

    public void StartGame()
    {
        GameManager.Instance.GameState = GameState.PLAY;
        Time.timeScale = 1;
        StartCoroutine(WaitToStartWaves(_levelData._level.TimeBeforeAttack));
    }

    IEnumerator WaitToStartWaves(float time)
    {
        yield return new WaitForSeconds(time);
        OnGameStart?.Invoke();
    }

    public void PauseGame()
    {
        GameManager.Instance.GameState = GameState.PAUSE;
        Time.timeScale = 0;
    }

    public void AddCurrency(int currency)
    {
        _resourceManager.AddCurrency(currency);
    }

    public bool CanUpgrade(int cost)
    {
        return _resourceManager.CanPurchase(cost);
    }

    public LevelData GetData()
    {
        return _levelData;
    }

    public void ChargeTurret(int amount)
    {
        _resourceManager.Purchase(amount);
    }
}