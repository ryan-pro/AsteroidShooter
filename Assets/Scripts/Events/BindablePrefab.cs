using UnityEngine;

namespace Shooter.Events
{
    [CreateAssetMenu(menuName = "Events/Bindable Prefab")]
    public class BindablePrefab : BindableValue<GameObject>
    {
        public GameObject Instantiated { get; set; }

        protected override void OnEnable() { }

        public void Raise() => Invoke(Value, this);

        public void DisposeInstantiated()
        {
            if (Instantiated != null)
                Destroy(Instantiated);
        }
    }
}