using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private GameObject _startBackground;

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}
