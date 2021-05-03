using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _fightButton;
        [SerializeField] private Button _rewardButton;
        [SerializeField] private GameObject _startBackground;
        [SerializeField] private TrailRenderer _trailRenderer;
        public Button _openInventory;

        public void InitGameStart(UnityAction startGame)
        {
            _startButton.onClick.AddListener(startGame);
        }

        public void InitFightWindow(UnityAction startFight)
        {
            _fightButton.onClick.AddListener(startFight);
        }

        public void InitRewardWindow(UnityAction showReward)
        {
            _rewardButton.onClick.AddListener(showReward);
        }

        public void OpenInventory(UnityAction open)
        {
            _openInventory.onClick.AddListener(open);
        }

        protected void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
        }
    }
}
