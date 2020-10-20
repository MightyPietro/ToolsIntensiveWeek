using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeBehavior))]
public class CubeBehaviorEditor : Editor
{
    Transform t;
    CubeBehavior c;
    private void OnEnable()
    {
        t = ((CubeBehavior)target).transform;
        c = ((CubeBehavior)target);
    }
    public void OnSceneGUI()
    {
        Handles.BeginGUI();
        EditorGUILayout.LabelField("aozdjaokdzpa");
        Handles.EndGUI();
        //for (int i = 0; i < c.outputVector.Length; i++)
        //{
        //    Handles.DrawLine(c.transform.position + c.outputVector[i], c.transform.position + c.outputVector[(i + 1) % c.outputVector.Length]);
        //    c.outputVector[i] =
        //    Handles.FreeMoveHandle(c.transform.position + c.outputVector[i], c.transform.rotation,
        //    .2f * HandleUtility.GetHandleSize(c.transform.position + c.outputVector[i]),
        //    Vector3.one, Handles.SphereHandleCap) - c.transform.position;
        //}
        //for (int i = 0; i < c.outputQuat.Length; i++)
        //{
        //    c.outputQuat[i] = 
        //    Handles.FreeRotateHandle( c.outputQuat[i],
        //    c.transform.position + c.outputVector[i],
        //    0.2f * HandleUtility.GetHandleSize(c.transform.position + c.outputVector[i]));
        //}

        c.radius = Handles.RadiusHandle(c.transform.rotation, c.transform.position, c.radius);


    }

    
}
