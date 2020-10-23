using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Atom Variables/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        public float Value;
        public GameEvent Event;

        public void SetValue(float value) { Value = value; RaiseEvent(); }
        public void AddToValue(float value) { Value += value; RaiseEvent(); }
        public void SoustractToValue(float value) { Value -= value; RaiseEvent(); }
        public void MultiplyToValue(float value) { Value *= value; RaiseEvent(); }
        public void DivideToValue(float value) { Value /= value; RaiseEvent(); }

        public void RaiseEvent() { if (Event != null) Event.Raise(); }

    }
}
