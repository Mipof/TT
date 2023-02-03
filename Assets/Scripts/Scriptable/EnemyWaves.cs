using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Waves", fileName = "Wave")]
public class EnemyWaves : ScriptableObject
{
    [Serializable]
    public struct EnemyQty
    {
        public string WavaName;
        public EnemyType EnemyType;
        public int Quantity;
        public float TimeDelay;
    }
    
    public EnemyQty[] _waves;

}
