using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _app;

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
    
    
    public static GameManager Instance
    {
        get => _app;
        set => _app = value;
    }

    public GameState GameState
    {
        get => GameState;
        set => GameState = value;
    }
}
