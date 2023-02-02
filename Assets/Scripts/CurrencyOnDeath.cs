using UnityEngine;
using UnityEngine.Events;

public class CurrencyOnDeath : MonoBehaviour
{
    public void SendCurrency(int currency)
    {
        GameManager.Instance.LevelManager.AddCurrency(currency);
    }
}
