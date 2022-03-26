using Shooter.Events;
using UnityEngine;

namespace Shooter.LifetimeManagement
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private TitleLifetime title;
        [SerializeField]
        private StageLifetime game;

        [Header("Listener Events")]
        [SerializeField]
        private GameEvent gameplayEnd;

        private void Awake()
        {
            title.gameObject.SetActive(false);
            game.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            gameplayEnd.AddListener(OnGameEnded);
            title.InitializeAndStart();
        }

        private void OnDisable()
        {
            gameplayEnd.RemoveListener(OnGameEnded);
        }

        public void OnGameStarted()
        {
            title.DisposeAndEnd();
            game.InitializeAndStart();
        }

        public void OnGameEnded() => OnGameEnded(this, System.EventArgs.Empty);
        private void OnGameEnded(object sender, System.EventArgs args)
        {
            game.DisposeAndEnd();
            title.InitializeAndStart();
        }

        public void OnGameExit()
        {
            title.gameObject.SetActive(false);
            game.gameObject.SetActive(false);

            Application.Quit();
        }
    }
}
