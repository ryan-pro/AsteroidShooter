using UnityEngine;

namespace Shooter.Gameplay
{
    [System.Serializable]
    public class InstructionData
    {
        [SerializeField]
        private WaveInstruction instruction;

        [Header("Additional")]
        [SerializeField]
        private SpawnPointData startPoint;
        [SerializeField]
        private SpawnPointData endPoint;

        public WaveInstruction Instruction => instruction;
        public SpawnPointData StartPoint => startPoint;
        public SpawnPointData EndPoint => endPoint;
    }
}