using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gameplay
{
    public class LevelHolderWindow : EditorWindow
    {
        
        public LevelHolder levelHolder;
        SerializedProperty chunksArray;
        SerializedProperty curveProperty;
        SerializedProperty keysValueProperty;
        SerializedObject serializedObject;
        int numberOfKeys;
        int numberOfLine;
        int j;
        Rect chunkRect;
        string assetName;
        LevelHolder templateLevelHolder;


        public static void Init(LevelHolder holder)
        {
            LevelHolderWindow window = EditorWindow.GetWindow(typeof(LevelHolderWindow)) as LevelHolderWindow;


            // Initialize window : start de la fenêtre
            window.levelHolder = holder;
            window.serializedObject = new SerializedObject(window.levelHolder);
            window.chunksArray = window.serializedObject.FindProperty(nameof(window.levelHolder.levelChunks));
            window.curveProperty = window.serializedObject.FindProperty(nameof(window.levelHolder.curve));
            window.keysValueProperty = window.serializedObject.FindProperty(nameof(window.levelHolder.keysValue));
            

            window.Show();
        }
        [MenuItem("Window/Levels Windows %&w")]

        public static void Init()
        {
            LevelHolderWindow window = EditorWindow.GetWindow(typeof(LevelHolderWindow)) as LevelHolderWindow;
            window.templateLevelHolder = Resources.Load<LevelHolder>("LevelHolder");

            // Initialize window : start de la fenêtre

            window.Show();
        }

        private void OnGUI()
        {
            
            
            if (levelHolder == null)
            {
                levelHolder = EditorGUILayout.ObjectField(levelHolder, typeof(LevelHolder)) as LevelHolder;
                assetName = GUILayout.TextField(assetName);
                if (assetName != "")
                {
                    if (GUILayout.Button("Create Level Holder Asset"))
                    {

                        LevelHolder newLevelHolder = new LevelHolder();
                        newLevelHolder.gameSpeedValues = new int[40];
                        newLevelHolder.levelChunks = new LevelChunk[40];
                        newLevelHolder.keysValue = new float[40];
                        newLevelHolder.curve = AnimationCurve.Linear(0, 0, 1, 1);
                        newLevelHolder.titleStyle = templateLevelHolder.titleStyle;
                        newLevelHolder.chunkStyle = templateLevelHolder.chunkStyle;
                        newLevelHolder.gameSpeedStyle = templateLevelHolder.gameSpeedStyle;

                        AssetDatabase.CreateAsset(newLevelHolder, "Assets/TestAssetCreation/" + assetName + ".asset");
                        

                        levelHolder = newLevelHolder;
                    }

                }

                if (levelHolder != null)
                {
                    
                    serializedObject = new SerializedObject(levelHolder);

                    chunksArray = serializedObject.FindProperty(nameof(levelHolder.levelChunks));
                    curveProperty = serializedObject.FindProperty(nameof(levelHolder.curve));
                    keysValueProperty = serializedObject.FindProperty(nameof(levelHolder.keysValue));
                }

            }
            else
            {
                serializedObject.Update();
                chunksArray = serializedObject.FindProperty(nameof(levelHolder.levelChunks));
                curveProperty = serializedObject.FindProperty(nameof(levelHolder.curve));

                for (int i = 0; i < chunksArray.arraySize; i++)
                {
                    if (i >= curveProperty.animationCurveValue.keys.Length)
                    {
                        levelHolder.levelChunks[i] = null;
                        levelHolder.gameSpeedValues[i] = 0;
                    }
                }

                j = -1;
                for (int i = 0; i < levelHolder.curve.keys.Length; i++)
                {
                    
                    j++;
                    if (i < 7) numberOfLine = 0;
                    else if (i >= 7 && i < 14) { numberOfLine = 1; }
                    else if (i >= 14 && i < 21) { numberOfLine = 2;}
                    else if(i >= 21 && i < 28) { numberOfLine = 3; }
                    else if(i >= 28 && i < 35) { numberOfLine = 4; }

                    switch (i)
                    {
                        case 7:
                            j = 0;
                            break;
                        case 14:
                            j = 0;
                            break;
                        case 21:
                            j = 0;
                            break;
                        case 28:
                            j = 0;
                            break;
                    }
                    

                    chunkRect = new Rect(10 + (j * position.width * .14f), 50 + (numberOfLine * 175), position.width * .1f, position.height * .1f);
                    

                    if (levelHolder.curve.keys[i].value < 1f / 8f) RectsPresets(chunkRect, Color.white, i, "Easy--", "Chunk : Easy", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 2f) RectsPresets(chunkRect, Color.green, i, "Easy", "Chunk : Medium","GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 3f) RectsPresets(chunkRect, Color.cyan, i, "Medium--", "Chunk : Easy", "GameSpeed : 2");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 4f) RectsPresets(chunkRect, Color.blue, i, "Medium", "Chunk : Medium", "GameSpeed : 2");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 5f) RectsPresets(chunkRect, Color.yellow, i, "Medium++", "Chunk : Hard", "GameSpeed : 1");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 6f) RectsPresets(chunkRect, Color.magenta, i, "Hard--", "Chunk : Easy", "GameSpeed : 3");
                    else if (levelHolder.curve.keys[i].value < 1f / 8f * 7f) RectsPresets(chunkRect, Color.red, i, "Hard", "Chunk : Hard", "GameSpeed : 2");
                    else if (levelHolder.curve.keys[i].value <= 1f / 8f * 8f) RectsPresets(chunkRect, Color.black, i, "Hard++", "Chunk : Medium", "GameSpeed : 3");

                }

                Rect curveRect = new Rect(10, chunkRect.y + chunkRect.height * 2, position.width * .94f, position.height *.2f);
                levelHolder.curve = EditorGUI.CurveField(curveRect, levelHolder.curve);
                if (position.width < 971) position = new Rect(position.x, position.y, 971, position.height);
                if (position.height < 970) position = new Rect(position.x, position.y, position.width, 970);
              


                serializedObject.ApplyModifiedProperties();
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
        

            Rect intRect = new Rect(rect.x, levelChunkRect.y + levelChunkRect.height, rect.width, rect.height * .22f);
            levelHolder.gameSpeedValues[i] = EditorGUI.IntField(intRect, levelHolder.gameSpeedValues[i]);
            Repaint();
            EditorUtility.SetDirty(levelHolder);
            
        }

    }
}


