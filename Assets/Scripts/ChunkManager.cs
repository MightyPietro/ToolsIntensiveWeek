using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ChunkManager : MonoBehaviour
    {
        [SerializeField] LevelHolder levelHolder;

        private void Start()
        {
            GameObject chunk = Instantiate(levelHolder.levelChunks[0].filledChunk) as GameObject;
            for (int i = 0; i < levelHolder.levelChunks[0].presetValues.Count; i++)
            {
                if (levelHolder.levelChunks[0].presetValues[i] == 1)
                {
                    Debug.Log(chunk.transform.GetChild(i));
                    chunk.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            
        }
    }
}

