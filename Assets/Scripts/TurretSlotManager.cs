using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;


public class TurretSlotManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GameObject _upgradeIcon;

    private GameObject _turret;
    private TurretData _data;

    /*private void LateUpdate()
    {
        if (_turret && _data._turret.CanUpgrade && _levelManager.CanUpgrade(_data._turret.CostToUpgrade))
        {
            _upgradeIcon.SetActive(true);
        }
        else
        {
            _upgradeIcon.SetActive(false);
        }
    }

    public void SetTurret(GameObject turret, TurretData data)
    {
        _turret = turret;
        _data = data;
    }

    public void UpgradeTurret()
    {
        if (_turret.TryGetComponent(out Turret turretScript))
        {
            turretScript.RemoveTurret();
        }
        else
        {
            throw new Exception("Turret" + _turret.name + " cannot found ");
        }
        
        _upgradeIcon.SetActive(false);

        _turret = Instantiate(_data._turret.UpgradePrefab, transform);

        if (_turret.TryGetComponent(out Turret turret))
        {
            _data = turret.GetData();
        }
        else
        {
            throw new Exception("Cant obtain data from " + _turret.transform.name);
        }
        
    }*/
}