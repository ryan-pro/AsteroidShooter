using Shooter.Enemies;
using Shooter.Events;
using UnityEngine;

namespace Shooter.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private BindableVector2 positionTracker;

        [SerializeField]
        private PlayerAbility[] abilities;

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

        public event System.EventHandler OnDeath;

        private void Update()
        {
            positionTracker.Value = ThisTransform.position;

            foreach (var a in abilities)
                a.UpdateActions();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.GetComponent<Enemy>() != null)
                OnKilledByEnemy();
        }

        private void OnKilledByEnemy()
        {
            //TODO: Trigger explosion
            Debug.Log("Player has been destroyed!");
            OnDeath?.Invoke(this, System.EventArgs.Empty);
        }
    }
}