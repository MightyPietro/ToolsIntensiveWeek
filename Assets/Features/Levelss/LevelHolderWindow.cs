using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gameplay
{
    public class LevelHolderWindow : EditorWindow
    {
        
        public LevelHolder levelHolder;
        [MenuItem("Window/Levels Windows %&#w")]


        public static void Init(LevelHolder levelHolder)
        {
            LevelHolderWindow window = EditorWindow.GetWindow(typeof(LevelHolderWindow)) as LevelHolderWindow;

            // Initialize window : start de la fenêtre
            window.levelHolder = levelHolder;
            window.Show();
        }
        public static void Init()
        {
            LevelHolderWindow window = EditorWindow.GetWindow(typeof(LevelHolderWindow)) as LevelHolderWindow;

            // Initialize window : start de la fenêtre

            window.Show();
        }

        private void OnGUI()
        {
            
        }

    }
}


