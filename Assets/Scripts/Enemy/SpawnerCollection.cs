using UnityEngine;

namespace Shooter.Enemies
{
    public class SpawnerCollection : MonoBehaviour
    {
        [SerializeField]
        private Spawner leftSpawner;
        [SerializeField]
        private Spawner middleSpawner;
        [SerializeField]
        private Spawner rightSpawner;

        private Spawner[] spawnerList;

        public Spawner this[SpawnPointSide side] => side switch
        {
            SpawnPointSide.Left => leftSpawner,
            SpawnPointSide.Top => middleSpawner,
            SpawnPointSide.Right => rightSpawner,
            _ => GetRandom()
        };

        public Vector2 GetSpawnPosition(SpawnPointSide spawnSide, int spawnIndex)
            => this[spawnSide].GetSpawnPosition(spawnIndex);

        private Spawner GetRandom()
        {
            if (spawnerList == null)
                spawnerList = new Spawner[] { leftSpawner, middleSpawner, rightSpawner };

            return spawnerList[Random.Range(0, spawnerList.Length)];
        }
    }
}