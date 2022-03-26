using UnityEngine;

namespace Shooter.Enemies
{
    public class MovementResolver : MonoBehaviour
    {
        [Header("General")]
        [SerializeField]
        private float moveSpeed = 5f;

        [SerializeField]
        private MotionType movementType = MotionType.Linear;

        [Header("Linear")]
        [SerializeField]
        private float linearDistanceFromPoint = 0.1f;

        [Header("Zig-Zag")]
        [SerializeField]
        private float zigZagTimeSeconds = 1f;
        [SerializeField]
        private bool zigZagOnY;
        [SerializeField]
        private float zigZagDistanceFromPoint = 1f;

        //General
        private Transform thisTransform;
        private Transform ThisTransform
        {
            get
            {
                if (thisTransform == null)
                    thisTransform = transform;

                return thisTransform;
            }
        }

        //Linear
        private Vector2 startPosition;

        private void OnDisable()
        {
            startPosition = Vector2.zero;
        }

        public void UpdateMovement(Vector2 destPosition)
        {
            if (startPosition == Vector2.zero)
                startPosition = ThisTransform.position;

            if (destPosition != default)
            {
                switch (movementType)
                {
                    case MotionType.Linear when Vector2.Distance(destPosition, ThisTransform.position) > linearDistanceFromPoint:
                        MoveLinear(destPosition);
                        return;

                    case MotionType.ZigZag when Vector2.Distance(destPosition, ThisTransform.position) > zigZagDistanceFromPoint:
                        MoveZigZag(destPosition);
                        return;
                }
            }

            var direction = ((ThisTransform.position + ThisTransform.up) - (Vector3)startPosition).normalized;
            ThisTransform.position += moveSpeed * Time.deltaTime * direction;
        }

        private void MoveLinear(Vector2 endPoint)
        {
            var direction = (endPoint - startPosition).normalized;
            ThisTransform.position += moveSpeed * Time.deltaTime * (Vector3)direction;
        }

        private void MoveZigZag(Vector2 endPoint)
        {
            var displacement = zigZagOnY
                ? new Vector2(0, zigZagDistanceFromPoint)
                : new Vector2(zigZagDistanceFromPoint, 0);

            var adjustment = Vector2.Lerp(displacement, -displacement, Mathf.PingPong(Time.time / zigZagTimeSeconds, 1));

            var direction = ((Vector3)(endPoint += adjustment) - ThisTransform.position).normalized;
            ThisTransform.position += moveSpeed * Time.deltaTime * direction;
        }

        public void ApplyExternalData(EnemyData data)
        {
            moveSpeed = data.MoveSpeed;
            movementType = data.MovementType;

            linearDistanceFromPoint = data.LinearDistanceFromPoint;

            zigZagTimeSeconds = data.ZigZigTimeSeconds;
            zigZagOnY = data.ZigZagOnY;
            zigZagDistanceFromPoint = data.ZigZagDistanceFromPoint;
        }
    }
}