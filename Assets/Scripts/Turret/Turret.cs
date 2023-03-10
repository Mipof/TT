using System.Collections;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Damage))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(LookAtCamera))]
public class Turret : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private TurretData[] _data;
    [SerializeField] private RuntimeAnimatorController[] _animations;
    [SerializeField] private GameObject _upgradeIcon;
    [SerializeField] private SphereCollider _sphereCollider;

    [Space(20)] 
    [SerializeField] private UnityEvent OnRemove;

    [SerializeField] private UnityEvent<int> OnNewDamage;
    [SerializeField] private UnityEvent<float> OnNewStatus;

    private int _indexUpgrade = 0;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private float _waitToUpdate = 2;
    private Animator _liveAnimator;
    private bool _ready;
    private bool _canUpdate = false;
    private LookAtCamera _lookAt;

    private void Awake()
    {
        _liveAnimator = GetComponent<Animator>();
        _lookAt = GetComponent<LookAtCamera>();
        OnNewDamage?.Invoke(_data[_indexUpgrade]._turret.DamagePerHit);
        OnNewStatus?.Invoke(_data[_indexUpgrade]._turret.StatusValue);
    }

    public void SetManager(LevelManager manager)
    {
        _levelManager = manager;
    }
    public float GetOffset()
    {
        return _offset;
    }

    public void FillLookAt(CameraEnum cameraEnum)
    {
        _lookAt.SetCamera(cameraEnum);
    }

    private void LateUpdate()
    {
        if(_ready && _canUpdate)
        {
            if (_data[_indexUpgrade]._turret.CanUpgrade &&
                _levelManager.CanUpgrade(_data[_indexUpgrade]._turret.CostToUpgrade))
            {
                _upgradeIcon.SetActive(true);
            }
            else
            {
                _upgradeIcon.SetActive(false);
            }
        }
    }

    public void RemoveTurret()
    {
        OnRemove?.Invoke();
    }

    public void UpgradeTurret()
    {
        if(_canUpdate)
        {
            _canUpdate = false;
            _upgradeIcon.SetActive(false);
            _levelManager.ChargeTurret(_data[_indexUpgrade]._turret.CostToUpgrade);
            StartCoroutine(CanUpdateDelay(_waitToUpdate));
            _indexUpgrade++;
            if (_data[_indexUpgrade]._turret.IsAnimated)
            {
                _liveAnimator.runtimeAnimatorController = _animations[_indexUpgrade];
            }

            if (_sphereCollider)
            {
                _sphereCollider.radius *= _data[_indexUpgrade]._turret.area;
            }
            OnNewDamage?.Invoke(_data[_indexUpgrade]._turret.DamagePerHit);
            OnNewStatus?.Invoke(_data[_indexUpgrade]._turret.StatusValue);
        }
        
    }

    IEnumerator CanUpdateDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _canUpdate = true;
    }

    public void SetReady()
    {
        if (_sphereCollider)
        {
            _sphereCollider.enabled = true;
        }
        _ready = true;
        StartCoroutine(CanUpdateDelay(_waitToUpdate));
    }
}
