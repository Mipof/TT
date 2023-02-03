using System;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int _currency;
    [SerializeField] private TextMeshProUGUI _currencyText;

    private void Start()
    {
        _currencyText.text = _currency.ToString();
    }

    public void Purchase(int cost)
    {
        if (_currency >= cost)
        {
            _currency -= cost;
            UpdateCurrencyText();
        }
    }

    public bool CanPurchase(int cost)
    {
        return cost <= _currency;
    }

    public void AddCurrency(int currency)
    {
        
        _currency += currency;
        UpdateCurrencyText();
    }

    private void UpdateCurrencyText()
    {
        _currencyText.text = _currency.ToString();
    }
}
