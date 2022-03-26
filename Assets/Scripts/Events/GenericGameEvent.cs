using UnityEngine;

namespace Shooter.Events
{
    public class GenericGameEvent<T> : ScriptableObject
    {
        private event System.EventHandler<T> handler;

        public void Invoke(T arg, object sender = null)
            => handler?.Invoke(sender ?? this, arg);

        public void AddListener(System.EventHandler<T> subscriber)
        {
            handler -= subscriber;
            handler += subscriber;
        }

        public void RemoveListener(System.EventHandler<T> subscriber)
        {
            handler -= subscriber;
        }
    }
}