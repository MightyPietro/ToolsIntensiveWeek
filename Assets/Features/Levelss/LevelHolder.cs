using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Levels/Holder")]
    public class LevelHolder : ScriptableObject
    {
        public LevelChunk[] levelChunks;
        public int[] gameSpeedValues;
        public int changedValue;
        public List<Keyframe> keysList = new List<Keyframe>();


        [HideInInspector]
        public LevelChunk fakedLevelChunk;
        public AnimationCurve curve;
        public GUIStyle titleStyle;
        public GUIStyle chunkStyle;
        public GUIStyle gameSpeedStyle;

        public void OpenWindow()
        {
            LevelHolderWindow.Init(this);
        }
    }
}

