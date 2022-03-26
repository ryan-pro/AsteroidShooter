using UnityEngine;

namespace Shooter.Enemies
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private float spawnRadius = 1f;
        [SerializeField]
        private Transform[] spawnPoints;

        private Transform thisTransform;
        private Transform ThisTransform
        {
            get
            {
                if (thisTransform == null)
                    thisTransform = transform;

                return thisTransform;
            }
        }

        public Vector3 InsideDirection => ThisTransform.up;

        public Vector2 GetSpawnPosition(int spawnIndex) => (spawnIndex < 0)
            ? (Vector2)spawnPoints[Random.Range(0, spawnPoints.Length)].position + (Random.insideUnitCircle * spawnRadius)
            : (Vector2)spawnPoints[spawnIndex].position + (Random.insideUnitCircle * spawnRadius);

        public Vector2 GetRandomSpawnPosition()
            => (Vector2)spawnPoints[Random.Range(0, spawnPoints.Length)].position + (Random.insideUnitCircle * spawnRadius);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            foreach (var point in spawnPoints)
                Gizmos.DrawWireSphere(point.position, spawnRadius);
        }
    }
}