using System.Collections.Generic;
using System.Linq;
using Doozy.Runtime.UIManager.Containers;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shared.Script
{
    public class Control : MonoBehaviour
    {
        public UIContainer result;
        private List<GameObject> items;

        private Timer timer;

        private void Start()
        {
            timer = FindObjectOfType<Timer>();

            items = new List<GameObject>();
            items = GameObject.FindGameObjectsWithTag("Item").ToList();
        }

        public void OpenAudio()
        {
            var audioSources = FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var audioSource in audioSources) audioSource.mute = false;
        }

        public void CloseAudio()
        {
            var audioSources = FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var audioSource in audioSources) audioSource.mute = true;
        }

        public void ResetGame()
        {
            foreach (var gameObject in items) gameObject.SetActive(true);

            FindObjectOfType<CharacterRespawner>().Respawn();

            FindObjectOfType<ScoreCounter>().SetScore(0);

            FindObjectOfType<PlayerBase>().effectAudioSource.clip = null;

            if (result.isVisible) result.Hide();

            timer.timeLimit = timer.maxTime;
        }

        public void BackToMain()
        {
            SceneManager.LoadScene("Shared/Start");
        }
    }
}