using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Turret", menuName = "Turrets/New turret")]
public class TurretData : ScriptableObject
{
   [Serializable]
   public struct Turret
   {
      public TurretType Type;
      public float DamagePerHit;
      public float Health;
      public int CostToBuild;
      public int CostToUpgrade;
   }

   public Turret _turret;


}
