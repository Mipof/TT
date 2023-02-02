using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Damage))]
[RequireComponent(typeof(Health))]
public class Turret : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private TurretData[] _data;
    [SerializeField] private RuntimeAnimatorController[] _animations;
    [SerializeField] private GameObject _upgradeIcon;

    [Space(20)] 
    [SerializeField] private UnityEvent OnRemove;

    [SerializeField] private UnityEvent<TurretData> OnNewTurret;

    private int _indexUpgrade = 0;
    private LevelManager _levelManager;
    private Animator _liveAnimator;

    private void Awake()
    {
        _liveAnimator = GetComponent<Animator>();
    }

    public void SetManager(LevelManager manager)
    {
        _levelManager = manager;
    }
    public float GetOffset()
    {
        return _offset;
    }

    private void LateUpdate()
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

    public void RemoveTurret()
    {
        OnRemove?.Invoke();
    }

    [ContextMenu("upgrade")]
    public void UpgradeTurret()
    {
        _indexUpgrade++;
        if(_data[_indexUpgrade]._turret.IsAnimated)
        {
            _liveAnimator.runtimeAnimatorController = _animations[_indexUpgrade];
        }
        OnNewTurret?.Invoke(_data[_indexUpgrade]);
        
    }
}
