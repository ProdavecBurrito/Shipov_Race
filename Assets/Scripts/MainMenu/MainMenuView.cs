using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _fightButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _startBackground;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private Button _openInventory;

        public void InitGameStart(UnityAction startGame)
        {
            _startButton.onClick.AddListener(startGame);
        }

        public void InitFightWindow(UnityAction startFight)
        {
            _fightButton.onClick.AddListener(startFight);
        }

        public void ExitApplication(UnityAction showReward)
        {
            _exitButton.onClick.AddListener(showReward);
        }

        public void OpenInventory(UnityAction open)
        {
            _openInventory.onClick.AddListener(open);
        }

        public void CloseInventory(UnityAction close)
        {
            _openInventory.onClick.AddListener(close);
        }

        protected void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
        }
    }
}
