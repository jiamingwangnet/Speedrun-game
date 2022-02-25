using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pong
{
    public class Tracker : MonoBehaviour
    {
        public int LeftScore { get; private set; }
        public int RightScore { get; private set; }

        [SerializeField] private TMP_Text displayText;

        public void IncreasePoints(GoalSide hitSide)
        {
            if (hitSide == GoalSide.Right)
                LeftScore++;
            else
                RightScore++;
        }


        private void Update()
        {
            displayText.text = $"{LeftScore}    -   {RightScore}";
        }
    }
}
