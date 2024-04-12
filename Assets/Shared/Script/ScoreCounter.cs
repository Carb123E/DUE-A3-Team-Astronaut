using System;
using UnityEngine;

namespace Shared.Script
{
    public class ScoreCounter : MonoBehaviour
    {
        public int maxScore;
        
        private int _currentScore;

        public Action OnScoreMax;
        
        public Action<int> OnScoreChange;

        public void ScoreAdd(int score)
        {
            currentScore += score;
            OnScoreChange?.Invoke(currentScore);
        }
        
        public void SetScore(int score)
        {
            currentScore = score;
            OnScoreChange?.Invoke(currentScore);
        }
        
        public int currentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                if (_currentScore >= maxScore)
                {
                    OnScoreMax?.Invoke();
                }
            }
        }
    }
}
