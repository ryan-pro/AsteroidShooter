using UnityEngine;

namespace Shooter.Gameplay
{
    public abstract class WaveInstruction : ScriptableObject
    {
        private System.Type instructionType;
        public System.Type InstructionType => instructionType ??= GetType();

        public abstract object GetInstruction();
    }
}