using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PlayerMovementBehavior : MonoBehaviour
    {
        [SerializeField] private GameEvent _OnPlayerMove;
        [SerializeField] private Transform _transform;
        [SerializeField] private Camera cam;

        private void Update() => Move();
        public void Move()
        {
            _transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, 0);
            _OnPlayerMove.Raise();
        }
    }

}
