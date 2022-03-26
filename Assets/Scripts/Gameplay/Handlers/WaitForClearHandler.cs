using Shooter.Enemies;
using System.Collections;
using UnityEngine;

namespace Shooter.Gameplay
{
    [System.Serializable]
    public class WaitForClearHandler : IInstructionHandler
    {
        [SerializeField]
        private EnemyTracker enemyTracker;

        [SerializeField]
        private float waitTimeBetweenChecks = 0.1f;

        public IEnumerator ProcessInstruction(InstructionData data)
        {
            while (enemyTracker.GetRemainingEnemyCount() > 0)
                yield return new WaitForSeconds(waitTimeBetweenChecks);
        }

        public void CleanUp() { }
    }
}