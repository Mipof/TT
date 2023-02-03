using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Turret", menuName = "Turrets/New turret")]
public class TurretData : ScriptableObject
{
   [Serializable]
   public struct Turret
   {
      public TurretType Type;
      public int DamagePerHit;
      public float StatusValue;
      public float Health;
      public int CostToBuild;
      public bool CanUpgrade;
      public int CostToUpgrade;
      public bool IsAnimated;
      public float Delay;
      public GameObject Prefab;
      public Sprite sprite;
      public float area;
   }

   public Turret _turret;


}
