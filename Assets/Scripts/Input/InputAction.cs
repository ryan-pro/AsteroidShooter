using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Controls
{
    [System.Serializable]
    public class InputAction
    {
        [SerializeField]
        private List<KeyCode> inputKeys;

        public bool Pressed(out KeyCode keyPressed)
        {
            keyPressed = KeyCode.None;

            foreach (var key in inputKeys)
            {
                if (Input.GetKey(key))
                {
                    keyPressed = key;
                    return true;
                }
            }

            return false;
        }

        public bool PressedDown(out KeyCode keyPressed)
        {
            keyPressed = KeyCode.None;

            foreach (var key in inputKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    keyPressed = key;
                    return true;
                }
            }

            return false;
        }
    }
}