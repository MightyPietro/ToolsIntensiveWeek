using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Levels/Chunk")]
    public class LevelChunk : ScriptableObject
    {
        public GameObject filledChunk;
        public List<Color> colorList;
        public List<Rect> rectList;
        public Color selectedColor;
        public List<int> presetValues;
        public bool isMouseDown;
        public int selectedValue;
        
        public void Create()
        {
            
            if (!isMouseDown)
            {
                Debug.Log(filledChunk.transform.childCount);
                
                
                isMouseDown = true;
            }

        }
    }
}

