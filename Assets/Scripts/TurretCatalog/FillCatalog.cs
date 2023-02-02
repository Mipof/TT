using UnityEngine;

public class FillCatalog : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private LevelData _levelData;
    private LevelManager _levelManager;
    

    private void OnEnable()
    {
        _levelManager = GameManager.Instance.LevelManager;
        _levelData = _levelManager.GetData();
        for (int i = 0; i < _levelData._turrets.Length; i++)
        {
            CreateCatalog(_levelData._turrets[i]);
        }
    }

    private void CreateCatalog(TurretData data)
    {
        GameObject prefab = Instantiate(_prefab, transform);
        if (prefab.TryGetComponent(out TurretIconSetter setter))
        {
            setter.SetTurretIcon(data._turret.Type.ToString(), data._turret.CostToBuild, data._turret.sprite, _levelManager);
        }
    }

    private void OnDisable()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}
