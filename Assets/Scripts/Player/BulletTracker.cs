using UnityEngine;

namespace Shooter.Player
{
    public class BulletTracker : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        [SerializeField]
        private TypedObjectPool<Bullet> pool;

        public Bullet SpawnBullet(bool setActive)
        {
            if (pool == null)
                pool = new TypedObjectPool<Bullet>(bulletPrefab, transform);

            var retrieved = pool.GetObject();
            retrieved.OnExpiration += OnExpiration;
            retrieved.gameObject.SetActive(setActive);

            return retrieved;
        }

        private void OnExpiration(object sender, System.EventArgs e)
        {
            var expired = (Bullet)sender;
            expired.OnExpiration -= OnExpiration;
            expired.gameObject.SetActive(false);
        }
    }
}