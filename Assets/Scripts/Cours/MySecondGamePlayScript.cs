using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MyCustomStruct
{
    public Color myStructColor;
    public float myStructFloat;
    public string myStructString;
}
public class MySecondGamePlayScript : MonoBehaviour
{
    public Color myColor;
    
    [Multiline]
    public string myString;
    [Header("Number")]
    [Range(0,50)]
    public int mySlider;
    public Vector2 myVector2;
    public string[] myArray;

    

    public MyCustomStruct myStruct;
}
