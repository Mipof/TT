using UnityEngine;

public class FillCatalog : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private UIManager _uiManager;
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
            setter.SetTurretIcon(data, _uiManager);
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
