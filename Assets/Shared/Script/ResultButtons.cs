using Doozy.Runtime.UIManager.Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shared.Script
{
    public class ResultButtons : MonoBehaviour
    {
        public UIButton home;

        public UIButton next;

        public UIButton restart;

        public bool enable;

        public string nextLevel;

        private void Start()
        {
            home.gameObject.SetActive(enable);
            next.gameObject.SetActive(enable);

            if (string.IsNullOrEmpty(nextLevel)) next.gameObject.SetActive(false);

            next.onClickEvent.AddListener(NextLevel);
            home.onClickEvent.AddListener(Home);
            restart.onClickEvent.AddListener(Restart);
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(nextLevel);
        }

        public void Home()
        {
            SceneManager.LoadScene("Shared/Start");
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}