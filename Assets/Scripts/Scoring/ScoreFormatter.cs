using UnityEngine;
using TMPro;

namespace Shooter.Scoring
{
    public class ScoreFormatter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textObj;
        [SerializeField]
        private string prefixText = "Score:";
        [SerializeField]
        private string scoreStringFormat = "00000";

        public void FormatAndUpdate(int score)
            => textObj.text = $"{prefixText.Trim()} {score.ToString(scoreStringFormat)}";
    }
}