using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Gameplay
{
    public class ChunkManager : Poolable
    {
        [SerializeField] LevelHolder levelHolder;
        [SerializeField] Pools enemiesPool;
        [SerializeField] private FloatVariable gameSpeed;
        private int k = -1;
        private IEnumerator Start()
        {
            k = -1;
            yield return new WaitForSeconds(.1f);
            for (int i = 0; i < levelHolder.levelChunks.Length; i++)
            {
                if (levelHolder.levelChunks != null)
                {
                    GameObject chunk = Instantiate(levelHolder.levelChunks[i].filledChunk) as GameObject;
                    chunk.transform.position = new Vector2(17, 0) + (new Vector2(17, 0) * i);
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

        public void ChangeGameSpeed()
        {
            k++;
            DOTween.To(() => gameSpeed.Value, x => gameSpeed.Value = x, levelHolder.gameSpeedValues[k],1);
        }
    }
}


