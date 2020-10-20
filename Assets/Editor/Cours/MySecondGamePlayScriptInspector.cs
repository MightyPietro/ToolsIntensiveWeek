using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MySecondGamePlayScript))]
public class MySecondGamePlayScriptInspector : Editor
{
    SerializedProperty myColorProperty;
    SerializedProperty redLevel;
    SerializedProperty myStrings;
    SerializedProperty myStruct;
    MySecondGamePlayScript mySecondGamePlayScript;

    private void OnEnable()
    {
        mySecondGamePlayScript = target as MySecondGamePlayScript;
        myColorProperty = serializedObject.FindProperty(nameof(mySecondGamePlayScript.myColor));
        redLevel = myColorProperty.FindPropertyRelative("r");
        myStrings = serializedObject.FindProperty("myArray");
        myStruct = serializedObject.FindProperty("myStruct");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(myColorProperty);
        EditorGUILayout.LabelField("Color Red ",redLevel.floatValue.ToString());

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add one")) myStrings.arraySize++;
        if (GUILayout.Button("Remove one")) myStrings.arraySize--;
        EditorGUILayout.EndHorizontal();
        if (myStrings.arraySize > 0)
        {
            for (int i = 0; i < myStrings.arraySize; i++)
            {
                EditorGUILayout.PropertyField(myStrings.GetArrayElementAtIndex(i), new GUIContent("String","Tooltip"));
            }
        }

        EditorGUILayout.PropertyField(myStruct);
        serializedObject.ApplyModifiedProperties();
        //serializedObject.ApplyModifiedPropertiesWithoutUndo();
    }
}
