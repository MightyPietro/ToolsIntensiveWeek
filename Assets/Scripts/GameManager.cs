using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent _OnReset;
    private void OnEnable() => _OnReset.Invoke();


}
