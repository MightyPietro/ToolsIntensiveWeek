using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemiesSpawner : Poolable
{
    private bool isWaiting;
    [SerializeField] private Pools enemiesPool;

    public void CallEnemies()
    {
        WakeAndPositionnate(enemiesPool, new Vector3(10, Random.Range(-3f, 5f), 0));
    }


}
