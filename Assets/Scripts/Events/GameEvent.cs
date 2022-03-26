using UnityEngine;

namespace Shooter.Events
{
    [CreateAssetMenu(menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private event System.EventHandler handler;

        public void Invoke(object sender = null)
            => handler?.Invoke(sender ?? this, System.EventArgs.Empty);

        public void AddListener(System.EventHandler subscriber)
        {
            handler -= subscriber;
            handler += subscriber;
        }

        public void RemoveListener(System.EventHandler subscriber)
        {
            handler -= subscriber;
        }
    }
}