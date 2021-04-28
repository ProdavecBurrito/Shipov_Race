using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _fightButton;
        [SerializeField] private GameObject _startBackground;
        [SerializeField] private TrailRenderer _trailRenderer;
        public Button _openInventory;

        public void InitGameStart(UnityAction startGame)
        {
            _startButton.onClick.AddListener(startGame);
        }

        public void InitFight(UnityAction startFight)
        {
            _fightButton.onClick.AddListener(startFight);
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
