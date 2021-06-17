using Profile;
using Tools;
using UnityEngine;

internal class FightMenuController : BaseController
{
    private Transform _placeForUi;
    private MainWindowObserver _windowObserver;
    private Camera _mainCamera;
    private PlayerProfile _playerProfile;

    public FightMenuController(Transform placeForUi, Camera mainCamera, PlayerProfile playerProfile)
    {
        _mainCamera = mainCamera;
        _placeForUi = placeForUi;
        _playerProfile = playerProfile;

        _windowObserver = ResourceLoader.LoadAndInstantiateObject<MainWindowObserver>(new ResourcePath { PathResource = "Prefabs/MainFightWindow" }, _placeForUi, false );
        var playerCar = ResourceLoader.LoadAndInstantiateObject<GameObject>(new ResourcePath { PathResource = "Prefabs/FightPlayerCar" }, _mainCamera.transform, false);
        var enemyCar = ResourceLoader.LoadAndInstantiateObject<GameObject>(new ResourcePath { PathResource = "Prefabs/EnemyCar" }, _mainCamera.transform, false);
        var fightBackground = ResourceLoader.LoadAndInstantiateObject<GameObject>(new ResourcePath { PathResource = "Prefabs/FightBackground" }, _mainCamera.transform, false);

        AddGameObjects(playerCar);
        AddGameObjects(enemyCar);
        AddGameObjects(fightBackground);
        AddGameObjects(_windowObserver.gameObject);
        _windowObserver.InitMainMenu(ReturnToMainMenu);
    }

    private void ReturnToMainMenu()
    {
        _playerProfile.CurrentState.Value = GameState.Start;
        _playerProfile.AnalyticTools.SendMessage("MainMenu");
    }
}