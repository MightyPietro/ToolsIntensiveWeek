using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyMovementBehavior : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private IntVariable gameSpeed;
        private void OnEnable()
        { 
            //rb.AddForce(-transform.right * 100 * gameSpeed.Value);
            StartCoroutine(WaitToUnactive());
        
        }

        private IEnumerator WaitToUnactive()
        {
            yield return new WaitForSeconds(5);
            if (gameObject.activeSelf) gameObject.SetActive(false);
        }
    }
}

