using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ShootBehavior : MonoBehaviour
    {
        [SerializeField] private GameEvent _OnPlayerShoot;
        [SerializeField] private UnityEngine.Events.UnityEvent _OnMouseClick;
        public Transform positionShootStart;

        public enum ProjectileType { normal }

        public ProjectileType projectileType;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) _OnMouseClick.Invoke();
        }

    }
}