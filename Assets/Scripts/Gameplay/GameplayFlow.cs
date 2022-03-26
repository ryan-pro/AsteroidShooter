using Shooter.Events;
using Shooter.Player;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class GameplayFlow : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private GameEvent gameEndEvent;

        [Header("Scene References")]
        [SerializeField]
        private PlayerTracker playerTracker;

        [SerializeField]
        private LevelFlow levels;
        [SerializeField]
        private GameObject levelCompleteScreen;

        private void OnEnable() => levelCompleteScreen.SetActive(false);

        public void StartGame()
        {
            playerTracker.SpawnPlayer();
            StartNextLevel();
        }

        public void StartNextLevel()
        {
            if (!levels.TryPlayNextLevel())
                gameEndEvent.Invoke(this);
        }

        public void OnLevelCompleted()
        {
            levels.DisposeHandlerObjects();
            levelCompleteScreen.SetActive(true);
        }

        public void ClearSpanwedObjects()
        {
            playerTracker.DespawnPlayer();
            levels.DisposeHandlerObjects();
            levelCompleteScreen.SetActive(false);
        }
    }
}