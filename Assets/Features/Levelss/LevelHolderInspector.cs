using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Gameplay
{
    [CustomEditor(typeof(LevelHolder))]
    public class LevelHolderInspector : Editor
    {
        private LevelHolder levelHolder;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Open Window"))
            {
                levelHolder = target as LevelHolder;
                levelHolder.OpenWindow();
            }
        }
    }
}

