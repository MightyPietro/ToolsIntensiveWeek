using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyMovementBehavior : MonoBehaviour
    {
        [SerializeField] private FloatVariable gameSpeed;
        [SerializeField] private Transform _transform;
        private void OnEnable()
        { 
            
            //StartCoroutine(WaitToUnactive());
        
        }

        private void FixedUpdate()
        {
            _transform.Translate(-Vector2.right * gameSpeed.Value * .04f);
        }
        private IEnumerator WaitToUnactive()
        {
            yield return new WaitForSeconds(10);
            if (gameObject.activeSelf) gameObject.SetActive(false);
        }
    }
}

