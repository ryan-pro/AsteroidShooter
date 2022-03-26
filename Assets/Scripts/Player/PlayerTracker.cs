using Shooter.Events;
using UnityEngine;

namespace Shooter.Player
{
    public class PlayerTracker : MonoBehaviour
    {
        [SerializeField]
        private Player playerPrefab;
        [SerializeField]
        private Vector2 startingPosition;

        [SerializeField]
        private GameEvent gameEndEvent;

        private Player cached;

        public void SpawnPlayer()
        {
            cached = Instantiate(playerPrefab, transform);
            cached.transform.position = startingPosition;
            cached.OnDeath += OnPlayerDeath;
        }

        public void DespawnPlayer()
        {
            if (cached == null)
                return;

            cached.OnDeath -= OnPlayerDeath;
            Destroy(cached.gameObject);
            cached = null;
        }

        private void OnPlayerDeath(object sender, System.EventArgs args)
        {
            var player = (Player)sender;
            player.OnDeath -= OnPlayerDeath;

            cached = null;
            Destroy(player.gameObject);
            gameEndEvent.Invoke();
        }
    }
}