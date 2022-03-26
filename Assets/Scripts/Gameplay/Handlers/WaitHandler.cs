using System.Collections;
using UnityEngine;

namespace Shooter.Gameplay
{
    [System.Serializable]
    public class WaitHandler : IInstructionHandler
    {
        public IEnumerator ProcessInstruction(InstructionData data)
        {
            var waitInstruction = (WaitInstruction)data.Instruction;
            yield return new WaitForSeconds((float)waitInstruction.GetInstruction());
        }

        public void CleanUp() { }
    }
}