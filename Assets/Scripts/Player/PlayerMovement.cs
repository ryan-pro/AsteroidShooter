using Shooter.Controls;
using UnityEngine;

namespace Shooter.Player
{
    public class PlayerMovement : PlayerAbility
    {
        [SerializeField]
        private float forwardSpeed = 1.5f;
        [SerializeField]
        private float backwardSpeed = 1f;
        [SerializeField]
        private float horizontalSpeed = 2f;
        [SerializeField]
        private InputAction upInput, downInput, leftInput, rightInput;

        public override void UpdateActions()
        {
            if (upInput.Pressed(out _))
                ThisTransform.position += forwardSpeed * Time.deltaTime * Vector3.up;
            if (downInput.Pressed(out _))
                ThisTransform.position += backwardSpeed * Time.deltaTime * Vector3.down;
            if (leftInput.Pressed(out _))
                ThisTransform.position += horizontalSpeed * Time.deltaTime * Vector3.left;
            if (rightInput.Pressed(out _))
                ThisTransform.position += horizontalSpeed * Time.deltaTime * Vector3.right;
        }
    }
}