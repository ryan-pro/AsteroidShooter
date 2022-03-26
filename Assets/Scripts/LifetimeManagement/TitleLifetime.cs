using UnityEngine;

namespace Shooter.LifetimeManagement
{
    public class TitleLifetime : MonoBehaviour, ILifetimeManager
    {
        public void InitializeAndStart() => gameObject.SetActive(true);
        public void DisposeAndEnd() => gameObject.SetActive(false);
    }
}
