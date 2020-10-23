using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class ScoreDisplayer : MonoBehaviour
    {
        [SerializeField] private IntVariable score;
        public void DisplayScore(Text scoreText)
        {
            scoreText.text = 00000000 + score.Value.ToString();
        }

        
        

    }
}

