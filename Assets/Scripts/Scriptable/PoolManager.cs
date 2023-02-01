using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPoolManager",menuName = "Pools/New pool manager")]
public class PoolManager : ScriptableObject
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
            Pools[i].Pool = CreateAPool(Pools[i]);
        }
    }

    public ObjectPool CreateAPool(EnemyPool enemyPool)
    {
        ObjectPool pool = new ObjectPool();
        pool.ObjectPrefab = enemyPool.Prefab;
        for (int j = 0; j < enemyPool.QuantityInstansiated; j++)
        {
            GameObject obj = pool.CreateNewGameObject();
            obj.SetActive(false);
        }
        return pool;
    }

    public EnemyPool GetPool(EnemyType type)
    {
        for (int i = 0; i < Pools.Length; i++)
        {
            if (Pools[i].TYPE == type)
            {
                return Pools[i];
            }
        }

        throw new Exception("Object pool: " + type + " dont instantiated");
    }
}