using Profile;
using UnityEngine;

internal sealed class GameStarter : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private float _speedCar;

    private MainController _mainController;

    private void Awake()
    {
        PlayerProfile profilePlayer = new PlayerProfile(_speedCar);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
