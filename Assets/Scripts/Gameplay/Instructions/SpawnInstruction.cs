using Shooter.Enemies;
using UnityEngine;

namespace Shooter.Gameplay
{
    [CreateAssetMenu(menuName = "Level Creation/Instructions/Enemy Spawn")]
    public class SpawnInstruction : WaveInstruction
    {
        [SerializeField]
        private EnemyData enemy;

        public override object GetInstruction() => enemy;
    }
}