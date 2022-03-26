using UnityEngine;

namespace Shooter.Gameplay
{
    [CreateAssetMenu(menuName = "Level Creation/Instructions/Wait")]
    public class WaitInstruction : WaveInstruction
    {
        [SerializeField]
        private float waitSeconds = 1f;

        public override object GetInstruction() => waitSeconds;
    }
}