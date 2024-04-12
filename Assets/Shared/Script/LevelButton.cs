using Doozy.Runtime.UIManager.Components;
using UnityEngine;

namespace _Scripts
{
    public class LevelButton : MonoBehaviour
    {
        public string levelName;

        private UIButton _button;

        private void Awake()
        {
            _button = GetComponent<UIButton>();
            _button.onClickEvent.AddListener(() => { GameManager.Instance.LoadScene(levelName); });
        }
    }
}