using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public enum GoalSide
    {
        Left,
        Right
    }

    public class Goal : MonoBehaviour
    {
        [SerializeField] private GoalSide side;
        [SerializeField] private Tracker tracker;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("ball"))
            {
                tracker.IncreasePoints(side);
            }
        }
    }
}
