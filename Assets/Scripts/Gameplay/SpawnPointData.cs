using Shooter.Enemies;
using Shooter.Events;
using UnityEngine;

namespace Shooter.Gameplay
{
    [CreateAssetMenu(menuName = "Level Creation/Enemy Spawn Position")]
    public class SpawnPointData : ScriptableObject
    {
        [Header("Custom Position")]
        [SerializeField]
        private BindableVector2 overridePosition;

        [Header("Using Spawners")]
        [SerializeField]
        private SpawnPointSide side = SpawnPointSide.Random;
        [SerializeField, Range(-1, 7)]
        private int spawnerIndex = -1;

        public BindableVector2 UpdatablePosition => overridePosition;

        public SpawnPointSide Side => side;
        public int SpawnerIndex => spawnerIndex;
    }
}