using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MyCustomStruct))]
public class MyStructDrawer : PropertyDrawer
{

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float numberOfLines = 2f;
        if (EditorGUIUtility.currentViewWidth < 332) numberOfLines++;
        return numberOfLines * (EditorGUIUtility.singleLineHeight + 2);
    }
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        Rect colorRect = new Rect(rect.x, rect.y, rect.width * .5f, EditorGUIUtility.singleLineHeight);
        Rect floatRect = new Rect(rect.x + rect.width *.5f , rect.y, rect.width * .5f, EditorGUIUtility.singleLineHeight);
        Rect stringRect = new Rect(rect.x + rect.width *.5f , rect.y + EditorGUIUtility.singleLineHeight + 2, rect.width * .5f, EditorGUIUtility.singleLineHeight);

        SerializedProperty colorProp = property.FindPropertyRelative("myStructColor");
        SerializedProperty floatProp = property.FindPropertyRelative("myStructFloat");
        SerializedProperty stringProp = property.FindPropertyRelative("myStructString");

        float oldWith = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth *= 0.4f;
        EditorGUI.PropertyField(colorRect, colorProp);
        EditorGUI.PropertyField(floatRect, floatProp);
        EditorGUI.PropertyField(stringRect, stringProp);

        EditorGUIUtility.labelWidth = oldWith;
    }

}
