using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _turretShopButton;
    [SerializeField] private GameObject _turretCatalog;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _instructions;

    private bool _isPause;

    private GrabTurret _grabTurret;

    private void Awake()
    {
        _grabTurret = GetComponent<GrabTurret>();
    }


    public void OpenCatalog()
    {
        _turretShopButton.SetActive(false);
        _turretCatalog.SetActive(true);
    }

    public void CloseCatalog()
    {
        _turretCatalog.SetActive(false);
        _turretShopButton.SetActive(true);
    }

    public void GrabTurret(TurretData data)
    {
        _grabTurret.GrabATurret(data);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPause)
            {
                _pauseMenu.SetActive(false);
                _isPause = false;
                Time.timeScale = 1;
            }
            else
            {
                _pauseMenu.SetActive(true);
                _isPause = true;
                Time.timeScale = 0;
            }
        }
    }

    public void Defeat()
    {
        Time.timeScale = 0;
        _loseScreen.SetActive(true);
    }
}