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
        SerializedProperty presetValues;
        int k;
        LevelChunk levelChunk;


        private void OnEnable()
        {
            levelChunk = target as LevelChunk;
            filledChunk = serializedObject.FindProperty(nameof(levelChunk.filledChunk));
            colorList = serializedObject.FindProperty(nameof(levelChunk.colorList));
            selectedColor = serializedObject.FindProperty(nameof(levelChunk.selectedColor));
            rectList = serializedObject.FindProperty(nameof(levelChunk.rectList));
            presetValues = serializedObject.FindProperty(nameof(levelChunk.presetValues));


        }

        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(filledChunk);
            //EditorGUILayout.PropertyField(colorList);
            //EditorGUILayout.PropertyField(selectedColor);
            //EditorGUILayout.PropertyField(rectList);
            //EditorGUILayout.PropertyField(presetValues);

             float viewWidth = EditorGUIUtility.currentViewWidth;
        GUILayout.Space(EditorGUIUtility.singleLineHeight * 150);
            Rect createRect = new Rect(20, 100, viewWidth * .92f, 40);
            EditorGUI.DrawRect(createRect, Color.black);
            EditorGUI.LabelField(new Rect(createRect.x + (viewWidth * .92f *.5f), createRect.y,createRect.width,createRect.height), " Create " );

            Rect backgroundRect = new Rect(5 , 295, viewWidth * 0.92f, viewWidth * 0.6f );
            EditorGUI.DrawRect(backgroundRect, new Color(levelChunk.selectedColor.r, levelChunk.selectedColor.g, levelChunk.selectedColor.b, .2f));

            Rect obstaclesRect = new Rect(20, 150, viewWidth / 4, 50);
            EditorGUI.DrawRect(obstaclesRect, Color.yellow);
            Rect enemiesRect = new Rect(25+ viewWidth / 4, 150, viewWidth / 4, 50);
            EditorGUI.DrawRect(enemiesRect, Color.red);
            k =-1 ;
            levelChunk.rectList.Clear();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    k++;
                    Rect jRect = new Rect(20 + ((viewWidth / 20 + 5) * i), 300 + (viewWidth / 20 + 5) * j, viewWidth / 20, viewWidth / 20);
                    levelChunk.rectList.Insert(k, jRect);
                    EditorGUI.DrawRect(jRect, levelChunk.colorList[k]);

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
                        levelChunk.presetValues[i] = levelChunk.selectedValue;
                        EditorGUI.DrawRect(levelChunk.rectList[i], levelChunk.selectedColor);
                        

                    }
                    else
                    {
                        EditorGUI.DrawRect(levelChunk.rectList[i], Color.grey);
                    }

                }
                else if (createRect.Contains(cur.mousePosition))
                {

                    if (cur.type == EventType.MouseDown)
                    {
                        levelChunk.Create();
                    }
                    else
                    {
                        EditorGUI.DrawRect(createRect, Color.grey);
                    }

                }
                else if (obstaclesRect.Contains(cur.mousePosition))
                {
                    if (cur.type == EventType.MouseDown)
                    {
                        levelChunk.selectedColor = Color.yellow;
                        levelChunk.selectedValue = 1;
                    }

                }
                else if (enemiesRect.Contains(cur.mousePosition))
                {
                    if (cur.type == EventType.MouseDown)
                    {
                        levelChunk.selectedColor = Color.red;
                        levelChunk.selectedValue = 2;
                    }

                }
            }

            if (cur.type == EventType.MouseUp) levelChunk.isMouseDown = false;

           
            Repaint();

            serializedObject.ApplyModifiedProperties();
        }

    }
}

