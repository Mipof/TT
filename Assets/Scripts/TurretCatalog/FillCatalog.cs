using UnityEngine;

public class FillCatalog : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private LevelData _levelData;
    

    private void OnEnable()
    {
        _levelData = GameManager.Instance.LevelManager.GetData();
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
            setter.SetTurretIcon(data._turret.Type.ToString(), data._turret.CostToBuild, data._turret.sprite);
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
