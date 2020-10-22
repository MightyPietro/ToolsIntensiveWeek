using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ChunkManager : Poolable
    {
        [SerializeField] LevelHolder levelHolder;
        [SerializeField] Pools enemiesPool;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(.1f);
            for (int i = 0; i < levelHolder.levelChunks.Count; i++)
            {
                GameObject chunk = Instantiate(levelHolder.levelChunks[i].filledChunk) as GameObject;
                chunk.transform.position = Vector2.zero + (new Vector2(15, 0) * i);
                for (int j = 0; j < levelHolder.levelChunks[i].presetValues.Count; j++)
                {
                    switch (levelHolder.levelChunks[i].presetValues[j])
                    {
                        case 0:
                            chunk.transform.GetChild(j).gameObject.SetActive(false);
                            break;
                        case 1:
                            chunk.transform.GetChild(j).gameObject.SetActive(false);
                            WakeAndPositionnate(enemiesPool, chunk.transform.GetChild(j).position);
                            break;
                        case 2:
                            break;

                    }

                }

            }
            
            
        }
    }
}

