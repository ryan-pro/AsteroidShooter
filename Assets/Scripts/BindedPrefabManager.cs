using Shooter.Events;
using UnityEngine;

namespace Shooter
{
    public class BindedPrefabManager : MonoBehaviour
    {
        [SerializeField]
        private BindablePrefab[] prefabs;

        private void OnEnable()
        {
            foreach (var bindable in prefabs)
                bindable.AddListener(OnBindableRaised);
        }

        private void OnDisable()
        {
            foreach (var bindable in prefabs)
            {
                bindable.RemoveListener(OnBindableRaised);
                bindable.DisposeInstantiated();
            }
        }

        private void OnBindableRaised(object sender, GameObject go)
            => ((BindablePrefab)sender).Instantiated = Instantiate(go, transform);
    }
}