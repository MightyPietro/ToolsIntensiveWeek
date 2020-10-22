using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gameplay
{
    public class LevelHolderWindow : EditorWindow
    {
        
        public LevelHolder levelHolder;
        int numberOfKeys;


        public static void Init(LevelHolder levelHolder)
        {
            LevelHolderWindow window = EditorWindow.GetWindow(typeof(LevelHolderWindow)) as LevelHolderWindow;

            // Initialize window : start de la fenêtre
            window.levelHolder = levelHolder;
            window.Show();
        }
        [MenuItem("Window/Levels Windows %&w")]

        public static void Init()
        {
            LevelHolderWindow window = EditorWindow.GetWindow(typeof(LevelHolderWindow)) as LevelHolderWindow;

            // Initialize window : start de la fenêtre

            window.Show();
        }

        private void OnGUI()
        {
            
            if (levelHolder == null)
            {
                levelHolder = EditorGUILayout.ObjectField(levelHolder, typeof(LevelHolder)) as LevelHolder;
            }
            else
            {
                levelHolder.curve = EditorGUILayout.CurveField(levelHolder.curve);

                if (numberOfKeys != levelHolder.curve.keys.Length)
                {

                    levelHolder.levelChunks = new LevelChunk[levelHolder.curve.keys.Length];
                    levelHolder.gameSpeedValues = new int[levelHolder.curve.keys.Length];
                    numberOfKeys = levelHolder.curve.keys.Length;
                }


                for (int i = 0; i < levelHolder.curve.keys.Length; i++)
                {
                    Rect chunkRect = new Rect(10 + (i * position.width * .14f), 50, position.width * .1f, position.height * .1f);

                    if(levelHolder.curve.keys[i].value < 1f / 8f) RectsPresets(chunkRect, Color.white, i, "Easy", "Chunk : Easy", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 2f) RectsPresets(chunkRect, Color.green, i, "Easy", "Chunk : Easy","GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 3f) RectsPresets(chunkRect, Color.cyan, i, "Easy", "Chunk : Easy", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 4f) RectsPresets(chunkRect, Color.blue, i, "Easy", "Chunk : Easy", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 5f) RectsPresets(chunkRect, Color.yellow, i, "Easy", "Chunk : Easy", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 6f) RectsPresets(chunkRect, Color.magenta, i, "Easy", "Chunk : Easy", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 7f) RectsPresets(chunkRect, Color.red, i, "Easy", "Chunk : Easy", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value <= 1f / 8f * 8f) RectsPresets(chunkRect, Color.black, i, "Easy", "Chunk : Easy", "GameSpeed : 1");

                }
            }
        }

        private void RectsPresets(Rect rect, Color color, int i,string title,string chunkTitle, string gameSpeedTitle)
        {
            
            EditorGUI.DrawRect(rect, color);
            
            
            Rect titleRect = new Rect(rect.x, rect.y, rect.width, rect.height * .5f);
            EditorGUI.LabelField(titleRect, title, levelHolder.titleStyle);
            EditorGUI.LabelField(titleRect, chunkTitle, levelHolder.chunkStyle);
            EditorGUI.LabelField(titleRect, gameSpeedTitle, levelHolder.gameSpeedStyle);
            

            Rect levelChunkRect = new Rect(rect.x, rect.y + rect.height, rect.width, rect.height * .5f);
            levelHolder.levelChunks[i] = EditorGUI.ObjectField(levelChunkRect, levelHolder.levelChunks[i], typeof(LevelChunk)) as LevelChunk;

            Event cur = Event.current;

            Rect intRect = new Rect(rect.x, levelChunkRect.y + levelChunkRect.height, rect.width, rect.height * .5f);

            levelHolder.gameSpeedValues[i] = EditorGUI.IntField(intRect, levelHolder.gameSpeedValues[i]);
            Repaint();
            
        }

    }
}


