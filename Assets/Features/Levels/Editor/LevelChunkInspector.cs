using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gameplay
{
    [CustomEditor(typeof(LevelChunk))]
    public class LevelChunkInspector : Editor
    {
        SerializedProperty filledChunk;
        SerializedProperty colorList;
        SerializedProperty selectedColor;
        SerializedProperty rectList;
        int k;
        LevelChunk levelChunk;


        private void OnEnable()
        {
            levelChunk = target as LevelChunk;
            filledChunk = serializedObject.FindProperty(nameof(levelChunk.filledChunk));
            colorList = serializedObject.FindProperty(nameof(levelChunk.colorList));
            selectedColor = serializedObject.FindProperty(nameof(levelChunk.selectedColor));
            rectList = serializedObject.FindProperty(nameof(levelChunk.rectList));


        }

        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(filledChunk);
            //EditorGUILayout.PropertyField(colorList);
            //EditorGUILayout.PropertyField(selectedColor);
            //EditorGUILayout.PropertyField(rectList);
            GUILayout.Space(EditorGUIUtility.singleLineHeight * 60);
            Rect backgroundRect = new Rect(5 , 295, EditorGUIUtility.currentViewWidth * 0.92f, EditorGUIUtility.currentViewWidth * 0.6f );
            EditorGUI.DrawRect(backgroundRect, new Color(levelChunk.selectedColor.r, levelChunk.selectedColor.g, levelChunk.selectedColor.b, .2f));

            Rect obstaclesRect = new Rect(20, 150, EditorGUIUtility.currentViewWidth / 4, 50);
            EditorGUI.DrawRect(obstaclesRect, Color.yellow);
            Rect enemiesRect = new Rect(25+ EditorGUIUtility.currentViewWidth / 4, 150, EditorGUIUtility.currentViewWidth / 4, 50);
            EditorGUI.DrawRect(enemiesRect, Color.red);
            k =-1 ;
            levelChunk.rectList.Clear();
            for (int i = 0; i < 15; i++)
            {
                k++;
                Rect newRect = new Rect(20 + ((EditorGUIUtility.currentViewWidth / 20 + 5) * i), 300, EditorGUIUtility.currentViewWidth / 20, EditorGUIUtility.currentViewWidth / 20);
                levelChunk.rectList.Add(newRect);
                EditorGUI.DrawRect(levelChunk.rectList[k], levelChunk.colorList[k]);
                
                for (int j = 0; j < 9; j++)
                {
                    k++;
                    Rect jRect = new Rect(20 + ((EditorGUIUtility.currentViewWidth / 20 + 5) * i), 300 + (EditorGUIUtility.currentViewWidth / 20 + 5) * j, EditorGUIUtility.currentViewWidth / 20, EditorGUIUtility.currentViewWidth / 20);
                    levelChunk.rectList.Add(jRect);
                    EditorGUI.DrawRect(levelChunk.rectList[k], levelChunk.colorList[k]);

                }
            }

            Event cur = Event.current;

            for (int i = 0; i < levelChunk.rectList.Count; i++)
            {
                if (levelChunk.rectList[i].Contains(cur.mousePosition))
                {


                    if (cur.button == 0 && cur.isMouse)
                    {
                        levelChunk.colorList[i] = levelChunk.selectedColor;
                        EditorGUI.DrawRect(levelChunk.rectList[i], levelChunk.selectedColor);

                    }
                    else
                    {
                        EditorGUI.DrawRect(levelChunk.rectList[i], Color.grey);
                    }

                }
                else if (obstaclesRect.Contains(cur.mousePosition))
                {
                    if (cur.button == 0 && cur.isMouse)
                    {
                        levelChunk.selectedColor = Color.yellow;
                    }

                }
                else if (enemiesRect.Contains(cur.mousePosition))
                {
                    if (cur.button == 0 && cur.isMouse)
                    {
                        levelChunk.selectedColor = Color.red;
                    }

                }
            }

            
            
            Repaint();

            serializedObject.ApplyModifiedProperties();
        }

    }
}

