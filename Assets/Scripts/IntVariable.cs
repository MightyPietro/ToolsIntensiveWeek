using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Atom Variables/Float Variable")]
    public class IntVariable : ScriptableObject
    {
        public int Value;
        public GameEvent Event;

        public void SetValue(int value) { Value = value; RaiseEvent(); }
        public void AddToValue(int value) { Value += value; RaiseEvent(); }
        public void SoustractToValue(int value) { Value -= value; RaiseEvent(); }
        public void MultiplyToValue(int value) { Value *= value; RaiseEvent(); }
        public void DivideToValue(int value) { Value /= value; RaiseEvent(); }

        public void RaiseEvent() { if (Event != null) Event.Raise(); }
    }
}

