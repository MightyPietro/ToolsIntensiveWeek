using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Die : MonoBehaviour,IKillable
    {
        [SerializeField] private UnityEngine.Events.UnityEvent _OnDie;
        void IKillable.Die()
        {
            _OnDie.Invoke();
            
        }
    }
}

