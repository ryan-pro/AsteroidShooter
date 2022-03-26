using Shooter.Enemies;
using System.Collections;
using UnityEngine;

namespace Shooter.Gameplay
{
    [System.Serializable]
    public class SpawnHandler : IInstructionHandler
    {
        [SerializeField]
        private Enemy genericEnemyPrefab;
        [SerializeField]
        private SpawnerCollection spawners;
        [SerializeField]
        private EnemyTracker tracker;

        [SerializeField]
        private float waitTimeAfterSpawn = 0.1f;

        public IEnumerator ProcessInstruction(InstructionData data)
        {
            var newEnemy = tracker.SpawnEnemy(genericEnemyPrefab, false);
            newEnemy.ApplyExternalData((EnemyData)data.Instruction.GetInstruction());

            var startPos = spawners.GetSpawnPosition(data.StartPoint.Side, data.StartPoint.SpawnerIndex);
            newEnemy.transform.position = startPos;
            newEnemy.transform.LookAt(spawners[data.StartPoint.Side].InsideDirection);

            if (data.EndPoint != null)
            {
                if (data.EndPoint.UpdatablePosition != null)
                    newEnemy.BindedDestination = data.EndPoint.UpdatablePosition;
                else
                    newEnemy.Destination = spawners.GetSpawnPosition(data.EndPoint.Side, data.EndPoint.SpawnerIndex);
            }
            else
            {
                newEnemy.Destination = startPos;
            }

            newEnemy.gameObject.SetActive(true);
            yield return new WaitForSeconds(waitTimeAfterSpawn);
        }

        public void CleanUp()
        {
            tracker.ClearAllEnemies();
        }
    }
}