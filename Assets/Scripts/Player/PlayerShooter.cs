using Shooter.Controls;
using UnityEngine;

namespace Shooter.Player
{
    public class PlayerShooter : PlayerAbility
    {
        [SerializeField]
        private BulletTracker tracker;
        [SerializeField]
        private InputAction shootInput;

        public override void UpdateActions()
        {
            if (shootInput.PressedDown(out _))
            {
                var bullet = tracker.SpawnBullet(false);

                bullet.transform.position = ThisTransform.position;
                bullet.gameObject.SetActive(true);
            }
        }
    }
}