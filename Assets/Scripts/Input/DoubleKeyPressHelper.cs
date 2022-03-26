using UnityEngine;

namespace Shooter.Controls
{
    [System.Serializable]
    public class DoubleKeyPressHelper
    {
        [SerializeField]
        private float timeBetweenPresses = 0.2f;

        public KeyCode LastKeyPressed { get; set; }
        public float TimePressed { get; set; }

        public bool WasDoublePressed(KeyCode keyPressed, float pressTime)
        {
            if (keyPressed != LastKeyPressed)
            {
                LastKeyPressed = keyPressed;
                TimePressed = pressTime;
                return false;
            }

            if (pressTime - TimePressed > timeBetweenPresses)
            {
                TimePressed = pressTime;
                return false;
            }

            TimePressed = 0f;
            return true;
        }
    }
}