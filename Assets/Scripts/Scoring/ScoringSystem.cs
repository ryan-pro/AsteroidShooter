using Shooter.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Shooter.Scoring
{
    public class ScoringSystem : MonoBehaviour
    {
        [System.Serializable]
        public class IntEvent : UnityEvent<int> { }

        [SerializeField]
        private BindableInt scoreKeeper;
        [SerializeField]
        private IntEvent onScoreChanged = new IntEvent();

        private void OnEnable()
        {
            scoreKeeper.AddListener(OnAddPoints);
            scoreKeeper.Value = 0;
        }

        private void OnDisable() => scoreKeeper.RemoveListener(OnAddPoints);

        public void OnAddPoints(object sender, int toAdd) => onScoreChanged.Invoke(scoreKeeper.Value);
        private void ResetScore() => scoreKeeper.Value = 0;
    }
}