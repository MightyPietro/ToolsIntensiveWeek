using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private IntVariable score;
        [SerializeField] private FloatVariable gameSpeed;
        private void Update()
        {
            score.Value = 10;
        }
    }
}

