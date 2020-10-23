using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Die : MonoBehaviour,IKillable
    {
        [SerializeField] private UnityEngine.Events.UnityEvent _OnDie;
        void IKillable.Die()
        {
            transform.position = new Vector2(0, 248);
            _OnDie.Invoke();
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (gameObject.CompareTag("Player") )
            {
                if (collision.CompareTag("Obstacles")) _OnDie.Invoke();
            }

        }
    }
}

