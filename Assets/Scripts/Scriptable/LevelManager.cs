using System;
using UnityEngine;

public class LevelManager : ScriptableObject
{
    [Serializable]
    public struct EnemyPool
    {
        public EnemyType TYPE;
        public ObjectPool Pool;
        public int QuantityInstansiated;
        public GameObject Prefab;
    }

    public EnemyPool[] Pools;

    public void CreatePools()
    {
        for (int i = 0; i < Pools.Length; i++)
        {
            CreateAPool(Pools[i]);
        }
    }

    public void CreateAPool(EnemyPool pool)
    {
        pool.Pool = new ObjectPool();
        pool.Pool.ObjectPrefab = pool.Prefab;
        for (int j = 0; j < pool.QuantityInstansiated; j++)
        {
            pool.Pool.ReturnGameObjectToPool(pool.Pool.CreateNewGameObject());
        }
    }

    public ObjectPool GetPool(EnemyType type)
    {
        for (int i = 0; i < Pools.Length; i++)
        {
            if (Pools[i].TYPE == type)
            {
                return Pools[i].Pool;
            }
        }

        throw new Exception("Object pool: " + type + " dont instantiated");
    }
}