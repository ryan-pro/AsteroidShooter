using Shooter.Events;
using Shooter.Player;
using UnityEngine;

namespace Shooter.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [Header("For Testing")]
        [SerializeField]
        private EnemyData enemyData;
        [SerializeField]
        private BindableVector2 bindedDestination;

        [Header("Parameters")]
        [SerializeField]
        private int startingHealth = 20;
        [SerializeField]
        private Vector3 startingScale = Vector3.one;

        [SerializeField]
        private float spinSpeed = 200f;

        [SerializeField]
        private float objectLifeTime = 5f;
        [SerializeField]
        private int scoreOnDeath = 100;

        [Header("Scene References")]
        [SerializeField]
        private Transform graphicTransform;
        [SerializeField]
        private MovementResolver movement;
        [SerializeField]
        private ObjectRenderEffects effects;

        private int currentHealth;
        private float currentLifeTime;
        private Vector2 destination;

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

        //Int for score
        public event System.EventHandler<int> OnDeath;

        public BindableVector2 BindedDestination
        {
            get => bindedDestination;
            set => bindedDestination = value;
        }

        public Vector2 Destination
        {
            get => bindedDestination == null ? destination : bindedDestination.Value;
            set => destination = value;
        }

        private void Awake()
        {
            currentHealth = startingHealth;
            currentLifeTime = objectLifeTime;

            thisTransform = transform;
        }

        private void OnEnable()
        {
            if (enemyData != null)
                ApplyExternalData(enemyData);

            ThisTransform.localScale = startingScale;
        }

        private void OnDisable()
        {
            enemyData = null;
            bindedDestination = null;

            currentHealth = startingHealth;
            currentLifeTime = objectLifeTime;
        }

        private void Update()
        {
            movement.UpdateMovement(Destination);
            HandleSpinning();

            currentLifeTime -= Time.deltaTime;

            if (currentLifeTime <= 0f)
                RemoveExpiredObject();
        }

        private void HandleSpinning()
        {
            graphicTransform.rotation *= Quaternion.AngleAxis(spinSpeed * Time.deltaTime, new Vector3(1, 1, 0));
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("OutOfBounds"))
            {
                RemoveExpiredObject();
                return;
            }

            if (collision.transform.CompareTag("Player"))
            {
                OnKilledByPlayer();
                return;
            }

            var collidedBullet = collision.transform.GetComponentInParent<Bullet>();
            if (collidedBullet != null)
            {
                collidedBullet.RemoveExpired();
                OnDamaged(collidedBullet.DamagePoints);
            }
        }

        private void OnDamaged(int dmgPoints)
        {
            currentHealth = Mathf.Max(currentHealth - dmgPoints, 0);

            if (currentHealth == 0)
                OnKilledByPlayer();
            else
                effects.TriggerDamageFlash();   //TODO: Also sfx
        }

        private void OnKilledByPlayer()
        {
            //TODO: Trigger explosion
            Debug.Log($"{name} has been destroyed!");
            OnDeath?.Invoke(this, scoreOnDeath);
        }

        private void RemoveExpiredObject()
        {
            OnDeath?.Invoke(this, 0);
        }

        public void ApplyExternalData(EnemyData data)
        {
            startingHealth = data.StartingHealth;
            startingScale = data.StartingScale;

            spinSpeed = data.SpinSpeed;

            objectLifeTime = data.ObjectLifeTime;
            scoreOnDeath = data.ScoreOnDeath;

            movement.ApplyExternalData(data);
        }
    }
}