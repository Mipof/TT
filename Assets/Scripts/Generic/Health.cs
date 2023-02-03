using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private float _maxHealth;
    [SerializeField] private float _actualHealth;
    [SerializeField] private float _shield;

    [SerializeField] private UnityEvent OnZeroHealth;
    [SerializeField] private UnityEvent OnZeroShield;

    public void SetMaxHealth(float max)
    {
        _maxHealth = max;
    }

    public void GetDamage(float damage)
    {
        if (_shield > damage)
        {
            _shield -= damage;
        }
        else
        {
            if(_shield > 0) OnZeroShield?.Invoke();
            GetDamageOnHealth(damage - _shield);
            _shield = 0;
        }
    }

    private void GetDamageOnHealth(float damage)
    {
        _actualHealth -= damage;
        if (_actualHealth <= 0)
        {
            OnZeroHealth?.Invoke();
        }
    }

    public void GetHeal(float heal)
    {
        _actualHealth += heal;
        if (_actualHealth > _maxHealth)
        {
            _actualHealth = _maxHealth;
        }
    }

    public void HealToMax()
    {
        _actualHealth = _maxHealth;
    }

    public void GetShield(float shield)
    {
        _shield += shield;
    }
}
