using System;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _app;
    private GameState _gameState;
    private CinemachineBrain _brain;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        _gameState = GameState.MENU;
    }


    public static GameManager Instance
    {
        get => _app;
        set => _app = value;
    }

    public GameState GameState
    {
        get => _gameState;
        set => _gameState = value;
    }

    public CinemachineBrain Brain
    {
        get => _brain;
        set => _brain = value;
    }
}
