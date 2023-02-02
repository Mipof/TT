using System;

using UnityEngine;

[CreateAssetMenu(fileName = "Level data", menuName = "Level/New level data")]
public class LevelData : ScriptableObject
{
    [Serializable]
    public struct Level
    {
        public string LevelName;
        public string LevelDescription;
        public int TimeBeforeAttack;
        public int InitialCurrency;
        
    }

    public Level _level;
}
