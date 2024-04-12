using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shared.Script
{
    public class Timer : MonoBehaviour
    {
        public float timeLimit;

        public TMP_Text timeText;

        private float _time;

        public Action OnTimeEnd;
        
        /// <summary>
        /// 
        /// </summary>
        [FormerlySerializedAs("time")] public float maxTime;

        private void Start()
        {
            maxTime=timeLimit;
        }

        private void Update()
        {
            timeLimit -= Time.deltaTime;
            timeText.text = ((int)timeLimit).ToString();
            if (timeLimit <= 0)
            {
                timeText.text = "0";
                OnTimeEnd?.Invoke();
            }
        }
    }
}