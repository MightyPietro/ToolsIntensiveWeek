using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class MouseManager : MonoBehaviour
    {
        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}

