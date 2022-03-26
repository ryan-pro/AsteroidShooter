using UnityEngine;
using UnityEngine.Events;

namespace Shooter.Controls
{
    public class InputListener : MonoBehaviour
    {
        [System.Serializable]
        public class KeyCodeUnityEvent : UnityEvent<KeyCode> { }

        [SerializeField]
        private InputAction keyInput;

        [SerializeField]
        private KeyCodeUnityEvent onKeyPressed;

        private void Update()
        {
            if(keyInput.PressedDown(out var keyPressed))
                onKeyPressed.Invoke(keyPressed);
        }
    }
}
