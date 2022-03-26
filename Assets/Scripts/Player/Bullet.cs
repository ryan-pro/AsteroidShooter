using UnityEngine;

namespace Shooter.Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private int damagePoints = 30;
        [SerializeField]
        private float moveSpeed = 6f;
        [SerializeField]
        private float lifeTime = 3f;

        private float currentLifeTime;

        public event System.EventHandler OnExpiration;

        public int DamagePoints => damagePoints;

        private void OnDisable()
        {
            currentLifeTime = 0f;
        }

        private void Update()
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.up;

            currentLifeTime += Time.deltaTime;

            if (currentLifeTime >= lifeTime)
                RemoveExpired();
        }

        public void RemoveExpired()
        {
            OnExpiration?.Invoke(this, System.EventArgs.Empty);
        }
    }
}