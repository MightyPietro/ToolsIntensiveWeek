using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MyFirstWindow : EditorWindow
{
    public LevelProfile currentProfile;


    [MenuItem("Window/MyFirstWindow %&#w")]
    public static void Init()
    {
        MyFirstWindow window = EditorWindow.GetWindow(typeof(MyFirstWindow)) as MyFirstWindow;

        // Initialize window : start de la fenêtre

        window.Show();
    }

    public static void InitWithContent(LevelProfile profile)
    {
        MyFirstWindow window = EditorWindow.GetWindow(typeof(MyFirstWindow)) as MyFirstWindow;

        window.currentProfile = profile;

        window.Show();
    }

    private void OnGUI()
    {
        if (currentProfile != null)
        {
            
            EditorGUILayout.LabelField("Currently displayed Profile : " + currentProfile.name);
            Rect closeButtonRect = new Rect(30, 200, 150, 30);
            Rect squareRect = new Rect(150, 150, 150, 300);
            if (GUI.Button(closeButtonRect, "Export to JSON"))
            {
                string json = JsonUtility.ToJson(currentProfile, true);
                string filePath = "Assets/myFirstCurve.json";
                File.WriteAllText(filePath, json);

            }
            Event cur = Event.current;

            if (squareRect.Contains(cur.mousePosition))
            {
                EditorGUI.DrawRect(squareRect, Color.blue); Repaint();

            }
            else
            {
                EditorGUI.DrawRect(squareRect, Color.cyan); Repaint();
            }
        }

     
    }
    public void OnOldGUI()
    {

        //EditorGUI.DrawRect(new Rect(30, 30, 100, 100), Color.cyan);

        //Rect closeButtonRect = new Rect(30, 200, 60, 20);
        //if (GUI.Button(closeButtonRect, "Close"))
        //    this.Close();

    }
}
