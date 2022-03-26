using UnityEngine;

namespace Shooter.Player
{
    public abstract class PlayerAbility : MonoBehaviour
    {
        private Transform thisTransform;
        protected Transform ThisTransform
        {
            get
            {
                if (thisTransform == null)
                    thisTransform = transform;

                return thisTransform;
            }
        }

        public abstract void UpdateActions();
    }
}