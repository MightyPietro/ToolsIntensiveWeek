using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gameplay
{
    public class EnemyShooterAllower : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Events.UnityEvent _OnChunkEnter;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<ShootBehavior>().enabled = true;
            }else if (collision.CompareTag("Chunk"))
            {
                _OnChunkEnter.Invoke();
            }
        }
    }
}

