using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PlayerMovementBehavior : MonoBehaviour
    {
        [SerializeField] private GameEvent _OnPlayerMove;
        [SerializeField] private Transform _transform;
        private Vector2 xLimits;
        private Vector2 yLimits;
        private Camera cam;

        private void OnEnable()
        { 
            cam = Camera.main;
            xLimits = cam.ScreenToWorldPoint(new Vector3(Screen.width,0,0));
            yLimits = cam.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
        
        }
        private void Update() => Move();
        public void Move()
        {
            if (_transform.position.x > yLimits.x && _transform.position.x < xLimits.x)
            {
                if (_transform.position.y > xLimits.y && _transform.position.y < yLimits.y)
                {
                    _transform.Translate(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * 0.3f);
                    _OnPlayerMove.Raise();

                }
                else if (_transform.position.y < xLimits.y)
                {
                    _transform.Translate(new Vector3(0, 0.01f, 0));
                }
                else
                {
                    _transform.Translate(new Vector3(0, -0.01f, 0));
                }
            }
            else if (_transform.position.x > xLimits.x)
            {
                _transform.Translate(new Vector3(-0.01f,0,0));
            }
            else
            {
                _transform.Translate(new Vector3(0.01f, 0, 0));
            }

        }
    }

}
