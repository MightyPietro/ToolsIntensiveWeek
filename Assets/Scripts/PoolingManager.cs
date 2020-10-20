using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Gameplay
{
    public class PoolingManager : MonoBehaviour
    {
        [SerializeField] private List<Pools> pools;

        private void Start()
        {
            InstantiatePool();
        }

        public void InstantiatePool()
        {
            for (int i = 0; i < pools.Count; i++)
            {
                pools[i].poolableInScene = Instantiate(pools[i].poolPrefab);
                SceneManager.MoveGameObjectToScene(pools[i].poolableInScene.gameObject, SceneManager.GetSceneByBuildIndex(1));
            }

        }

    }
}
