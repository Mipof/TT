using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/New enemy")]
public class EnemyData : ScriptableObject
{
    [Serializable]
    public struct Enemy
    {
        public EnemyType Type;
        public float Health;
        public float Shield;
        public float Speed;
        public float DamagePerHit;
    }

    public Enemy _enemy;
}
