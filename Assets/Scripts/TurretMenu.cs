using System.Collections;
using UnityEngine;

public class TurretMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _turrets;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _maxRayDistance = 20;
    [SerializeField] private LayerMask _groundLayer;

    private float _turretOffset;

    private GameObject _heldTurret;
    private bool _hold;
    
    public void GrabATurret(int index)
    {
        if (!_hold)
        {
            _heldTurret = Instantiate(_turrets[index]);
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
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

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
