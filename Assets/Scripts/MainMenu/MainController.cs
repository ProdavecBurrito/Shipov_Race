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
    private MainRewardWindowController _mainRewardWindowController;
    private readonly Transform _placeForUi;
    private readonly Transform _placeForInventory;
    private readonly PlayerProfile _playerProfile;
    private Camera _mainCamera;
    private GameObject _car;

    public MainController(Transform placeForUi, Transform placeForInventory, Transform placeForReward, PlayerProfile profilePlayer, Camera mainCamera, GameObject car)
    {
        _car = car;
        _mainCamera = mainCamera;
        _playerProfile = profilePlayer;
        _placeForUi = placeForUi;
        _placeForInventory = placeForInventory;

        OnChangeGameState(_playerProfile.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        _mainRewardWindowController = new MainRewardWindowController(placeForReward);
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
                _gameController = new GameController(_placeForUi, _playerProfile, _car);
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
