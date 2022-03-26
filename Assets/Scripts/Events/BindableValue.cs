using UnityEngine;

namespace Shooter.Events
{
    public class BindableValue<T> : GenericGameEvent<T>
    {
        [SerializeField]
        private T value;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                Invoke(this.value);
            }
        }

        protected virtual void OnEnable() => Value = default;
    }
}