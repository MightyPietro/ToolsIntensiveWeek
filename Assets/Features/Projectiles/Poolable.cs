using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Poolable : MonoBehaviour
    {
        public void WakeAndPositionnate(Pools pool, Vector2 position)
        {
            for (int i = 0; i < pool.poolableInScene.childCount; i++)
            {
                if (!pool.poolableInScene.GetChild(i).gameObject.activeSelf)
                {
                   
                    pool.poolableInScene.GetChild(i).gameObject.SetActive(true);
                    pool.poolableInScene.GetChild(i).position = position;
                    break;
                }
            }
        }
        

    }
}

