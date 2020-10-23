using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Levels/Holder")]
    public class LevelHolder : ScriptableObject
    {

        public LevelChunk[] levelChunks;
        [HideInInspector]
        public int[] gameSpeedValues;
        [HideInInspector]
        public float[] keysValue;
        [HideInInspector]
        public int changedValue;
        [HideInInspector]
        public List<Keyframe> keysList = new List<Keyframe>();



        [HideInInspector]
        public LevelChunk fakedLevelChunk;
        [HideInInspector]
        public AnimationCurve curve;
        [HideInInspector]
        public GUIStyle titleStyle;
        [HideInInspector]
        public GUIStyle chunkStyle;
        [HideInInspector]
        public GUIStyle gameSpeedStyle;

        
    }
}

