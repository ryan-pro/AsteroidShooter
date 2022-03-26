using Shooter.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Enemies
{
    public class EnemyTracker : MonoBehaviour
    {
        [SerializeField]
        private BindableInt scoreKeeper;

        private readonly Dictionary<Enemy, GameObjectPool> pools = new Dictionary<Enemy, GameObjectPool>();

        public T SpawnEnemy<T>(T enemyType, bool setActive) where T : Enemy
        {
            if (!pools.ContainsKey(enemyType))
                pools.Add(enemyType, new GameObjectPool(enemyType.gameObject, transform));

            var retrieved = pools[enemyType].GetObject().GetComponent<Enemy>();

            retrieved.OnDeath += OnEnemyDeath;
            retrieved.gameObject.SetActive(setActive);

            return (T)retrieved;
        }

        public int GetRemainingEnemyCount()
        {
            int count = 0;
            foreach (var pool in pools.Values)
                count += pool.GetActiveObjectCount();

            return count;
        }

        public void ClearAllEnemies()
        {
            foreach (var p in pools.Values)
                p.DestroyAllObjects();
        }

        private void OnEnemyDeath(object sender, int points)
        {
            var retired = (Enemy)sender;
            retired.OnDeath -= OnEnemyDeath;
            retired.gameObject.SetActive(false);

            scoreKeeper.Value += points;
        }
    }
}