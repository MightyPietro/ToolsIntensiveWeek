using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ProjectileBehavior : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private FloatVariable gameSpeed;

        public enum EmitterType { player,enemy}

        public EmitterType emitterType;
        

        public bool isProjectileFromPlayer;
        private void OnEnable()
        {
            if (isProjectileFromPlayer) rb.AddForce(transform.right * 1000);
            else rb.AddForce(-transform.right * 1000 );

            StopAllCoroutines();
            StartCoroutine(WaitToUnactive());
        }

        private IEnumerator WaitToUnactive()
        {
            yield return new WaitForSeconds(1);
            if (gameObject.activeSelf) gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.GetComponent<Die>())
            {
                switch (emitterType)
                {
                    case EmitterType.player:
                        if (collision.gameObject.CompareTag("Enemy"))
                        {
                            collision.GetComponent<IKillable>().Die();
                            gameObject.GetComponent<IKillable>().Die();
                        }
                        break;
                    case EmitterType.enemy:
                        if (collision.gameObject.CompareTag("Player"))
                        {
                            collision.GetComponent<IKillable>().Die();
                            gameObject.GetComponent<IKillable>().Die();
                        }
                        break;

                }

            }else if (collision.CompareTag("Obstacles"))
            {
                gameObject.GetComponent<IKillable>().Die();
            }
        }
    }

}
