using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretIconSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turretName;
    [SerializeField] private TextMeshProUGUI _turretCost;
    [SerializeField] private  Image _turretImage;

    private UIManager _uiManager;
    private TurretData _data;

    public void SetTurretIcon(TurretData data, UIManager uiManager)
    {
        _turretName.text = data._turret.Type.ToString();
        _turretCost.text = data._turret.CostToUpgrade.ToString();
        _turretImage.sprite = data._turret.sprite;
        _uiManager = uiManager;
        _data = data;
    }

    public void GrabTurret()
    {
        _uiManager.GrabTurret(_data);
    }
    
}
