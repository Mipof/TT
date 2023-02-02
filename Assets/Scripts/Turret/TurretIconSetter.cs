using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretIconSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turretName;
    [SerializeField] private TextMeshProUGUI _turretCost;
    [SerializeField] private Image _turretImage;

    private LevelManager _levelManager;

    public void SetTurretIcon(string name, int cost, Sprite image, LevelManager manager)
    {
        _turretName.text = name;
        _turretCost.text = cost.ToString();
        _turretImage.sprite = image;
        _levelManager = manager;
    }

    public void GenerateTurret()
    {
        
    }
}