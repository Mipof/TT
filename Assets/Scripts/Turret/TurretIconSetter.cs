using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretIconSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turretName;
    [SerializeField] private TextMeshProUGUI _turretCost;
    [SerializeField] private  Image _turretImage;

    public void SetTurretIcon(string name, int cost, Sprite image)
    {
        _turretName.text = name;
        _turretCost.text = cost.ToString();
        _turretImage.sprite = image;
    }
}
