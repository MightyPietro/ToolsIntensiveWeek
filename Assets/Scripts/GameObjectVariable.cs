using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Atom Variables/GameObject Variable")]
    public class GameObjectVariable : ScriptableObject
    {
        public int Value;

        public void SetValue(int value) => Value = value;
    }
}

