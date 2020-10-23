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
        SerializedProperty difficulty;
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
            difficulty = serializedObject.FindProperty(nameof(levelChunk.difficulty));


        }

        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            //EditorGUILayout.PropertyField(filledChunk);
            //EditorGUILayout.PropertyField(colorList);
            //EditorGUILayout.PropertyField(selectedColor);
            //EditorGUILayout.PropertyField(rectList);
            //EditorGUILayout.PropertyField(presetValues);
            EditorGUILayout.PropertyField(difficulty);

             float viewWidth = EditorGUIUtility.currentViewWidth;
             GUILayout.Space(EditorGUIUtility.singleLineHeight * 150);
            //Rect createRect = new Rect(20, 100, viewWidth * .92f, 40);
            //EditorGUI.DrawRect(createRect, Color.black);
            //EditorGUI.LabelField(new Rect(createRect.x + (viewWidth * .92f *.5f), createRect.y,createRect.width,createRect.height), " Create " );

            

            

            Rect emptyRect = new Rect(50, 150, viewWidth * .2f, viewWidth * .2f);
            EditorGUI.DrawRect(emptyRect, Color.grey);
            DrawSprite(emptyRect, levelChunk.emptySprite);
            EditorGUI.LabelField(new Rect(emptyRect.x + (emptyRect.width * .5f) - 20, 155 + emptyRect.height  , 40,20),"Void");

            Rect enemiesRect = new Rect(emptyRect .x+ viewWidth / 4, 150, viewWidth *.2f, viewWidth *.2f);
            EditorGUI.DrawRect(enemiesRect, Color.red);
            DrawSprite(enemiesRect, levelChunk.enemySprite);
            EditorGUI.LabelField(new Rect(enemiesRect.x + (enemiesRect.width * .5f) - 20, 155 + enemiesRect.height, 40, 20), "Enemy");

            Rect obstaclesRect = new Rect(emptyRect.x + viewWidth / 2, 150, viewWidth * .2f, viewWidth * .2f);
            EditorGUI.DrawRect(obstaclesRect, Color.yellow);
            DrawSprite(obstaclesRect, levelChunk.obstacleSprite);
            EditorGUI.LabelField(new Rect( obstaclesRect.x + (obstaclesRect.width * .5f) - 25, 155 + obstaclesRect.height, 70, 20), "Obstacle");

            Rect backgroundRect = new Rect(5 , 325, viewWidth * 0.92f, viewWidth * 0.6f );
            EditorGUI.DrawRect(backgroundRect, new Color(levelChunk.selectedColor.r, levelChunk.selectedColor.g, levelChunk.selectedColor.b, .2f));
            k =-1 ;
            levelChunk.rectList.Clear();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    k++;
                    Rect jRect = new Rect(20 + ((viewWidth / 20 + 5) * i), 350 + (viewWidth / 20 + 5) * j, viewWidth / 20, viewWidth / 20);
                    levelChunk.rectList.Insert(k, jRect);
                    //EditorGUI.DrawRect(jRect, levelChunk.colorList[k]);
                    DrawSprite(jRect, levelChunk.spritesList[k]);
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
                        levelChunk.spritesList[i] = levelChunk.selectedSprite;
                        //EditorGUI.DrawRect(levelChunk.rectList[i], levelChunk.selectedColor);
                        DrawSprite(levelChunk.rectList[i], levelChunk.selectedSprite);

                    }
                    else
                    {
                        EditorGUI.DrawRect(levelChunk.rectList[i], Color.grey);
                    }

                }
                else if (obstaclesRect.Contains(cur.mousePosition))
                {
                    if (cur.type == EventType.MouseDown)
                    {
                        levelChunk.selectedColor = Color.yellow;
                        levelChunk.selectedValue = 2;
                        levelChunk.selectedSprite = levelChunk.obstacleSprite;
                    }

                }
                else if (enemiesRect.Contains(cur.mousePosition))
                {
                    if (cur.type == EventType.MouseDown)
                    {
                        levelChunk.selectedColor = Color.red;
                        levelChunk.selectedValue = 1;
                        levelChunk.selectedSprite = levelChunk.enemySprite;
                    }

                }
                else if (emptyRect.Contains(cur.mousePosition))
                {
                    if (cur.type == EventType.MouseDown)
                    {
                        levelChunk.selectedColor = Color.grey;
                        levelChunk.selectedValue = 0;
                        levelChunk.selectedSprite = levelChunk.emptySprite;
                    }

                }
            }

            if (cur.type == EventType.MouseUp) levelChunk.isMouseDown = false;


            Undo.RecordObject(levelChunk, "UnPaint");

            Repaint();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawSprite(Rect position, Sprite sprite)
        {
            // on récupère la taille du sprite, en pixels, dans le référentiel de la texture d'où il est issu
            Vector2 fullSize = new Vector2(sprite.texture.width, sprite.texture.height);
            Vector2 size = new Vector2(sprite.textureRect.width, sprite.textureRect.height);

            // on récupère les coordonnées du sprite au sein de la texture au format UV, c'est à dire entre 0 et 1
            Rect coords = sprite.textureRect;
            coords.x /= fullSize.x;
            coords.width /= fullSize.x;
            coords.y /= fullSize.y;
            coords.height /= fullSize.y;

            // quelle différence d'échelle de taille entre la texture réelle et l'espace qu'on a en GUI pour la dessiner ?
            Vector2 ratio;
            ratio.x = position.width / size.x;
            ratio.y = position.height / size.y;
            float minRatio = Mathf.Min(ratio.x, ratio.y);

            // on corrige la position/taille du rectangle où tracer la texture en GUI
            Vector2 center = position.center;
            position.width = size.x * minRatio;
            position.height = size.y * minRatio;
            position.center = center;

            // enfin, on dessine le morceau de texture correspondant au sprite
            GUI.DrawTextureWithTexCoords(position, sprite.texture, coords, true);
        }

    }
}

