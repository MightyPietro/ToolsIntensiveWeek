using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName ="Projectiles")]
    public class Pools : ScriptableObject
    {
        public Transform poolPrefab;
        public Transform poolableInScene;
    }
}

