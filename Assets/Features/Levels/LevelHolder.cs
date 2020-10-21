using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Levels/Holder")]
    public class LevelHolder : ScriptableObject
    {
        public LevelChunk[] levelChunks;
    }
}

