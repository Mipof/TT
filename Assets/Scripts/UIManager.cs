using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _turretShopButton;
    [SerializeField] private GameObject _turretCatalog;


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
}
