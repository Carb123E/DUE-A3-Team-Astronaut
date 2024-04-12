using Doozy.Runtime.UIManager.Visual;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shared.Script
{
    public class PlayerBase : MonoBehaviour
    {
        public ScoreCounter scoreCounter;

        public AudioSource effectAudioSource;

        public AudioSource bgmAudioSource;

        public AudioClip winAudio;

        public AudioClip loseAudio;

        public AudioClip pickAudio;

        public AudioClip buttonAudio;

        public AudioClip backgroundAudio;

        public int maxScore;

        public Progress progress;

        public Timer timer;

        public float timeLimit;

        public Image audioButton;
        public Sprite audio;
        public Sprite audioOff;
        public UIToggleSpriteSwapper audioButtonSwapper;

        public Image resetButton;
        public Sprite reset;

        public Image helpButton;
        public Sprite help;

        public Image homeButton;
        public Sprite homePage;

        public TMP_Text helpTextLeft;

        public TMP_Text helpTextRight;

        public string helpTextLeftStr;

        public string helpTextRightStr;

        public TMP_Text resultText;

        public string winTextStr;

        public Color winTextColor;

        public Color loseTextColor;

        public string loseTextStr;

        public string nextLevelStr;

        private void Awake()
        {
            progress.scoreCounter.maxScore = maxScore;

            timer.timeLimit = timeLimit;

            FindObjectOfType<ResultButtons>().nextLevel = nextLevelStr;
        }

        private void Start()
        {
            audioButton.sprite = audio;

            audioButtonSwapper.onSprite = audio;
            audioButtonSwapper.offSprite = audioOff;

            resetButton.sprite = reset;

            helpButton.sprite = help;

            homeButton.sprite = homePage;

            helpTextLeft.text = helpTextLeftStr;

            helpTextRight.text = helpTextRightStr;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item"))
            {
                scoreCounter.ScoreAdd(other.GetComponent<ItemBase>().score);
                Debug.Log($"pick {other.gameObject.name}");
                other.gameObject.SetActive(false);
                if (pickAudio != null && effectAudioSource.clip != winAudio)
                    effectAudioSource.clip = pickAudio;
                effectAudioSource.Play();
            }
        }
    }
}