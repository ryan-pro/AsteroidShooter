using System.Collections;

namespace Shooter.Gameplay
{
    public interface IInstructionHandler
    {
        IEnumerator ProcessInstruction(InstructionData instruction);
        void CleanUp();
    }
}