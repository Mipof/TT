using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _turretShopButton;
    [SerializeField] private GameObject _turretCatalog;

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
}
