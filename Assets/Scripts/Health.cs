using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField][Min(1)] private float _maxHealth;
    [SerializeField] private float _actualHealth;
    [SerializeField] private float _shield;

    [SerializeField] private UnityEvent OnZeroHealth;
    [SerializeField] private UnityEvent OnZeroShield;


    public void GetDamage(int damage)
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

    public void GetHeal(int heal)
    {
        _actualHealth += heal;
        if (_actualHealth > _maxHealth)
        {
            _actualHealth = _maxHealth;
        }
    }

    public void GetShield(int shield)
    {
        _shield += shield;
    }
}
