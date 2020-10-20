using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Atom Variables/Int Variable")]
    public class IntVariable : ScriptableObject
    {
        public int Value;

        public void SetValue(int value) => Value = value;
        public void AddToValue(int value) => Value += value;
        public void SoustractToValue(int value) => Value -= value;
        public void MultiplyToValue(int value) => Value *= value;
        public void DivideToValue(int value) => Value /= value;
    }
}


