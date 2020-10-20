﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ProjectileBehavior : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        public bool isProjectileFromPlayer;
        private void OnEnable()
        {
            if (isProjectileFromPlayer) rb.AddForce(transform.right * 1000);
            else rb.AddForce(-transform.right * 1000);

            StopAllCoroutines();
            StartCoroutine(WaitToUnactive());
        }

        private IEnumerator WaitToUnactive()
        {
            yield return new WaitForSeconds(2);
            if (gameObject.activeSelf) gameObject.SetActive(false);
        }
    }

}
