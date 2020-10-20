using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gameplay
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventInspector : Editor
    {
        private GameEvent gameEvent;
        private void OnEnable()
        {
            gameEvent = target as GameEvent;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.BeginVertical();

            if (GUILayout.Button("Raise"))
            {
                gameEvent.Raise();
            }

            GUILayout.EndVertical();
        }
    }
}

