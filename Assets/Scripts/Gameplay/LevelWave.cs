using UnityEngine;

namespace Shooter.Gameplay
{
    [CreateAssetMenu(menuName = "Level Creation/Wave")]
    public class LevelWave : IterableObjectCollection<InstructionData>
    {
        public override void Refresh() => listIndex = 0;
    }
}