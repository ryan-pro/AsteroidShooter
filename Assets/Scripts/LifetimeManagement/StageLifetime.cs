using Shooter.Gameplay;
using UnityEngine;

namespace Shooter.LifetimeManagement
{
    public class StageLifetime : MonoBehaviour, ILifetimeManager
    {
        [SerializeField]
        private GameplayFlow gameplay;

        public void InitializeAndStart()
        {
            gameObject.SetActive(true);
            gameplay.StartGame();
        }

        public void DisposeAndEnd()
        {
            gameObject.SetActive(false);
            gameplay.ClearSpanwedObjects();
        }
    }
}
