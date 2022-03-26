using Shooter.Controls;
using System.Collections;
using UnityEngine;

namespace Shooter.Player
{
    public class PlayerDash : PlayerAbility
    {
        [SerializeField]
        private float dashDistance = 2f;
        [SerializeField]
        private float dashTime = 0.1f;
        [SerializeField]
        private DoubleKeyPressHelper doublePressHelper;
        [SerializeField]
        private InputAction leftInput, rightInput;

        public override void UpdateActions()
        {
            if (leftInput.PressedDown(out var leftKey) && doublePressHelper.WasDoublePressed(leftKey, Time.time))
            {
                StopAllCoroutines();
                StartCoroutine(ExecuteDash(false));
            }
            else if (rightInput.PressedDown(out var rightKey) && doublePressHelper.WasDoublePressed(rightKey, Time.time))
            {
                StopAllCoroutines();
                StartCoroutine(ExecuteDash(true));
            }
        }

        private IEnumerator ExecuteDash(bool right)
        {
            var startPosition = ThisTransform.position;
            var endPosition = startPosition + ((right ? Vector3.right : Vector3.left) * dashDistance);

            var elapsed = 0f;
            while (elapsed < dashTime)
            {
                elapsed += Time.deltaTime;
                ThisTransform.position = Vector2.Lerp(startPosition, endPosition, elapsed / dashTime);
                yield return null;
            }
        }
    }
}