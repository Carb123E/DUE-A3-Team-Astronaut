using Doozy.Runtime.UIManager.Containers;
using TMPro;
using UnityEngine;

namespace Shared.Script
{
    public class Progress : MonoBehaviour
    {
        public TMP_Text current;

        public TMP_Text max;

        public ScoreCounter scoreCounter;

        /// <summary>
        ///     game-over-result-text
        /// </summary>
        public TMP_Text resultText;

        /// <summary>
        ///     game-over-result-container
        /// </summary>
        public UIContainer resultContainer;

        public Timer timer;

        private void Start()
        {
            current.text = scoreCounter.currentScore.ToString();

            max.text = $"/ {scoreCounter.maxScore.ToString()}";

            scoreCounter.OnScoreChange += newScore => { current.text = newScore.ToString(); };

            timer.OnTimeEnd += Lose;

            scoreCounter.OnScoreMax += Win;
        }


        private void Win()
        {
            resultText.text = FindObjectOfType<PlayerBase>().winTextStr;
            resultText.color = FindObjectOfType<PlayerBase>().winTextColor;
            var player = FindObjectOfType<PlayerBase>();

            if (player.winAudio != null)
                player.effectAudioSource.clip = player.winAudio;
            player.effectAudioSource.Play();

            Debug.Log("win");
            resultContainer.Show();
        }

        private void Lose()
        {
            resultText.text = FindObjectOfType<PlayerBase>().loseTextStr;
            resultText.color = FindObjectOfType<PlayerBase>().loseTextColor;

            var player = FindObjectOfType<PlayerBase>();
            if (player.loseAudio != null)
                player.effectAudioSource.clip = player.loseAudio;
            player.effectAudioSource.Play();

            resultContainer.Show();
        }
    }
}