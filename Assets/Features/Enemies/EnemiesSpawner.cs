using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemiesSpawner : Poolable
{
    private bool isWaiting;
    [SerializeField] private Pools enemiesPool;

    private void Update()
    {
            if (!isWaiting) StartCoroutine(WaitToSpawn());
    }
    IEnumerator WaitToSpawn()
    {
        isWaiting = true;
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        WakeAndPositionnate(enemiesPool, new Vector3(10, Random.Range(-3f, 5f), 0));
        isWaiting = false;
    }


}
