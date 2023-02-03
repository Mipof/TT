using UnityEngine;
using UnityEngine.UI;

public class TreeHpBar : MonoBehaviour
{
   [SerializeField] private Image _image;
   private int _maxHealth;

   public void SetMaxHalth(int max)
   {
      _maxHealth = max;
   }

   public void UpdateHealthBar(int total)
   {
      float hp = 1 / _maxHealth * total;
      _image.fillAmount = hp;
   } 
}
