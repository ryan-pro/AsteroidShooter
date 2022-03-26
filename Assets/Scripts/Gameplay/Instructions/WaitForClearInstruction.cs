using UnityEngine;

namespace Shooter.Gameplay
{
    [CreateAssetMenu(menuName = "Level Creation/Instructions/Wait for Clear")]
    public class WaitForClearInstruction : WaveInstruction
    {
        public override object GetInstruction() => null;
    }
}