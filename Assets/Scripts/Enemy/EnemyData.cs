using UnityEngine;

namespace Shooter.Enemies
{
    [CreateAssetMenu(menuName = "Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("General Parameters")]
        [SerializeField]
        private int startingHealth = 20;
        [SerializeField]
        private Vector3 startingScale = Vector3.one;

        [SerializeField]
        private float spinSpeed = 200f;

        [SerializeField]
        private float objectLifeTime = 5f;
        [SerializeField]
        private int scoreOnDeath = 100;

        [Header("Movement Parameters")]
        [SerializeField]
        private float moveSpeed = 5f;
        [SerializeField]
        private MotionType movementType;

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

        public int StartingHealth => startingHealth;
        public Vector3 StartingScale => startingScale;

        public float SpinSpeed => spinSpeed;

        public float ObjectLifeTime => objectLifeTime;
        public int ScoreOnDeath => scoreOnDeath;

        public float MoveSpeed => moveSpeed;
        public MotionType MovementType => movementType;

        public float LinearDistanceFromPoint => linearDistanceFromPoint;

        public float ZigZigTimeSeconds => zigZagTimeSeconds;
        public bool ZigZagOnY => zigZagOnY;
        public float ZigZagDistanceFromPoint => zigZagDistanceFromPoint;
    }
}