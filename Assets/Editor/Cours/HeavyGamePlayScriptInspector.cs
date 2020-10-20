using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(MyHeavyGamePlayScript))]
[CanEditMultipleObjects]
public class HeavyGamePlayScriptInspector : Editor
{


    private MyHeavyGamePlayScript myTargetScript;
    public void OnEnable()
    {
        Undo.undoRedoPerformed += RecalculateStuffAfterUndo;
        myTargetScript = target as MyHeavyGamePlayScript;
    }

    private void RecalculateStuffAfterUndo()
    {

    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical();

        #region properties

        myTargetScript.foldOutState = EditorGUILayout.Foldout(myTargetScript.foldOutState, "Properties");
        if (myTargetScript.foldOutState)
        {
            myTargetScript.myTransform = EditorGUILayout.ObjectField("Transform", myTargetScript.myTransform, typeof(Transform), true) as Transform;
            myTargetScript.cam = EditorGUILayout.ObjectField("Camera", myTargetScript.cam, typeof(Camera), true) as Camera;
            myTargetScript.light = EditorGUILayout.ObjectField("Light", myTargetScript.light, typeof(Light), true) as Light;
            myTargetScript.audioListener = EditorGUILayout.ObjectField("Audio Listener", myTargetScript.audioListener, typeof(AudioListener), true) as AudioListener;
        }

        int oldIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel += 2;
        myTargetScript.color = EditorGUILayout.ColorField("Ma Couleur", myTargetScript.color);
        myTargetScript.vector2 = EditorGUILayout.Vector2Field("Mon Vector", myTargetScript.vector2);
        EditorGUI.indentLevel = oldIndent ;
        #endregion

        #region boutons

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Auto-Set References"))
        {
            AutoSetReferences();
        }
        GUILayout.BeginVertical();
        if (GUILayout.Button("Auto-Set References"))
        {
            AutoSetReferences();
        }if (GUILayout.Button("Auto-Set References"))
        {
            AutoSetReferences();
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        #endregion 


        GUILayout.EndVertical();
        //EditorUtility.SetDirty(myTargetScript);
        EditorSceneManager.MarkAllScenesDirty();

    }

    private void AutoSetReferences()
    {
        

        Undo.RecordObject(myTargetScript, "Just set references");

        myTargetScript.audioListener = Object.FindObjectOfType<AudioListener>();
        myTargetScript.myTransform = Object.FindObjectOfType<Transform>();
        myTargetScript.light = Object.FindObjectOfType<Light>();
        myTargetScript.cam = Object.FindObjectOfType<Camera>();
    }
    public void OnDisable()
    {
        Undo.undoRedoPerformed -= RecalculateStuffAfterUndo;
    }
}
