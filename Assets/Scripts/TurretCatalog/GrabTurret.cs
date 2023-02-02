using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class GrabTurret : MonoBehaviour
{
    [SerializeField] private float _maxRayDistance = 20;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private CinemachineBrain _brain;
    private float _turretOffset;
    
    private GameObject _heldTurret;
    private bool _hold;

    public void GrabATurret(TurretData _data)
    {
        if (!_hold)
        {
            _heldTurret = Instantiate(_data._turret.Prefab);
            if (_heldTurret.TryGetComponent(out Turret turret))
            {
                _turretOffset = turret.GetOffset();
            }
            StartCoroutine(HeldTurretRoutine());    
        }
    }

    IEnumerator HeldTurretRoutine()
    {
        while (_heldTurret)
        {
            Ray ray = _brain.OutputCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxRayDistance, _groundLayer))
            {
                _heldTurret.transform.position = PositionWithOffset(hitInfo.point, _turretOffset);
                
                
                if (Input.GetMouseButton(0) 
                    && hitInfo.collider.CompareTag("TurretSlot")
                    && hitInfo.collider.transform.childCount == 0)
                {
                    _heldTurret.transform.position = PositionWithOffset(hitInfo.transform.position,_turretOffset);

                    _heldTurret.transform.SetParent(hitInfo.transform);
                    _heldTurret = null;
                }
            }
            yield return null;
        }
    }

    private Vector3 PositionWithOffset(Vector3 pos, float offset)
    {
        return pos + new Vector3(0f, offset,0f);
    }
}
