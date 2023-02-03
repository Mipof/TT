using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class GrabTurret : MonoBehaviour
{
    [SerializeField] private float _maxRayDistance = 20;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private CinemachineBrain _brain;
    [SerializeField] private LevelManager _levelManager;
    private float _turretOffset;

    private GameObject _heldTurret;
    private UIManager _ui;
    private bool _hold;

    private void Awake()
    {
        _ui = GetComponent<UIManager>();
    }

    public void GrabATurret(TurretData data)
    {
        if (!_heldTurret)
        {
            _ui.CloseCatalog();
            _heldTurret = Instantiate(data._turret.Prefab);
            if (_heldTurret.TryGetComponent(out Turret turret))
            {
                turret.SetManager(_levelManager);
                _turretOffset = turret.GetOffset();
            }

            StartCoroutine(HeldTurretRoutine(data));
        }
    }

    IEnumerator HeldTurretRoutine(TurretData data)
    {
        while (_heldTurret)
        {
            Ray ray = _brain.OutputCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _heldTurret.transform.position = PositionWithOffset(hitInfo.point, _turretOffset);


                if (Input.GetMouseButton(0)
                    && hitInfo.collider.CompareTag("TurretSlot")
                    && hitInfo.collider.transform.childCount == 0)
                {
                    _heldTurret.transform.position = PositionWithOffset(hitInfo.transform.position, _turretOffset);
                    if (_heldTurret.TryGetComponent(out LookAtCameraWhileHolding lookat))
                    {
                        lookat.Stop();   
                    }

                    _heldTurret.transform.rotation = new Quaternion(0, 0, 0, 0);
                    _heldTurret.transform.Rotate(new Vector3(2,0,0),Space.Self);  

                    _heldTurret.transform.SetParent(hitInfo.transform);
                    if (_heldTurret.TryGetComponent(out Turret turret))
                    {
                        turret.SetReady();
                        _levelManager.ChargeTurret(data._turret.CostToBuild);
                    }
                    _heldTurret.transform.localScale = new Vector3(0.1f,4f, 0.1f);
                    
                    _heldTurret = null;
                    
                    
                }

                if (Input.GetMouseButton(1))
                {
                    if (_heldTurret && _heldTurret.TryGetComponent(out Turret turret))
                    {
                        turret.RemoveTurret();
                    }

                    _heldTurret = null;
                }
            }

            yield return null;
        }
    }

    private Vector3 PositionWithOffset(Vector3 pos, float offset)
    {
        return pos + new Vector3(0f, offset, 0f);
    }
}