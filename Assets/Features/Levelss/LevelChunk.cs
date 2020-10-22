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
        public Sprite emptySprite;
        public Sprite obstacleSprite;
        public Sprite enemySprite;
        public List<Sprite> spritesList;

        public enum Difficulty { easy, medium, hard}

        public Difficulty difficulty;
        public int selectedValue;
        public Sprite selectedSprite;
        public bool isMouseDown;
    }
}

