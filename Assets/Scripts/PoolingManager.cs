using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PoolingManager : MonoBehaviour
    {
        public ShootCaller shootCaller;

        [SerializeField] private Transform normalPool;
        private void OnEnable() => shootCaller.poolingManager = this;
        public void WakeInPool(ShootBehavior shoot)
        {
            switch (shoot.projectileType)
            {
                case ShootBehavior.ProjectileType.normal:
                    WakeAndPositionnate(normalPool, shoot.positionShootStart.position);
                    break;
            }
        }

        private void WakeAndPositionnate(Transform pool,Vector2 position)
        {
            for (int i = 0; i < pool.childCount; i++)
            {
                if (!pool.GetChild(i).gameObject.activeSelf)
                {
                    pool.GetChild(i).gameObject.SetActive(true);
                    pool.GetChild(i).position = position;
                    break;
                }
            }
        }
    }
}

