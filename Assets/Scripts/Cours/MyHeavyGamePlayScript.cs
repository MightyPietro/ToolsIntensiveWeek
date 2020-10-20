using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeavyGamePlayScript : MonoBehaviour
{
    public Transform myTransform;
    public Camera cam;
    public Light light;
    public AudioListener audioListener;
    
    public Color color;
    public Vector2 vector2;

    #region UNITY_EDITOR
#if UNITY_EDITOR
    public bool foldOutState;
#endif
    #endregion
}
