using Game;
using Profile;
using System.Collections.Generic;
using Ui;
using UnityEngine;

internal sealed class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private FightMenuController _fightController;
    private readonly Transform _placeForUi;
    private readonly Transform _placeForInventory;
    private readonly PlayerProfile _playerProfile;
    private Camera _mainCamera;

    public MainController(Transform placeForUi, Transform placeForInventory, PlayerProfile profilePlayer, Camera mainCamera)
    {
        _mainCamera = mainCamera;
        _playerProfile = profilePlayer;
        _placeForUi = placeForUi;
        _placeForInventory = placeForInventory;
        OnChangeGameState(_playerProfile.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _placeForInventory, _playerProfile);
                _gameController?.Dispose();
                _fightController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _playerProfile);
                _mainMenuController?.Dispose();
                break;
            case GameState.Fight:
                _fightController = new FightMenuController(_placeForUi, _mainCamera, _playerProfile);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _fightController?.Dispose();
                break;
        }
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _playerProfile.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }
}
