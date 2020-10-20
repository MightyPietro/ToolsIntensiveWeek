using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ShootBehavior : Poolable
    {
        public bool isPlayer;
        private bool isWaiting;
        [SerializeField] private UnityEngine.Events.UnityEvent _OnMouseClick;
        [SerializeField] private UnityEngine.Events.UnityEvent _OnEnemyShoot;
        [SerializeField] private Transform positionShootStart;
        public Pools projectilePool;

        private void Update()
        {
            if (isPlayer)
            {
                if (Input.GetMouseButtonDown(0)) _OnMouseClick.Invoke();
            }
            else
            {
                if (!isWaiting) StartCoroutine(WaitToShoot());
            }

        }

        IEnumerator WaitToShoot()
        {
            isWaiting = true;
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            _OnEnemyShoot.Invoke();
            isWaiting = false;
        }

        public void Shoot() => SetShootBehavior();

        private void SetShootBehavior()
        {
            for (int i = 0; i < projectilePool.poolableInScene.childCount; i++)
            {
                if (isPlayer) projectilePool.poolableInScene.GetChild(i).GetComponent<ProjectileBehavior>().isProjectileFromPlayer = true;
                else projectilePool.poolableInScene.GetChild(i).GetComponent<ProjectileBehavior>().isProjectileFromPlayer = false;
            }
            WakeAndPositionnate(projectilePool, positionShootStart.position);
        }

        



    }
}