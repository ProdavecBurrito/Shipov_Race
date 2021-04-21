using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _mainMenuPath = new ResourcePath { PathResource = "Prefabs/MainMenu" };
        private readonly ResourcePath _invenventoryPath = new ResourcePath { PathResource = "Prefabs/InventoryView" };
        private readonly PlayerProfile _profilePlayer;
        private MainMenuView _view;

        public MainMenuController(Transform placeForUi, PlayerProfile profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject mainMenu = Object.Instantiate(ResourceLoader.LoadPrefab(_mainMenuPath), placeForUi, false);
            GameObject inventotyView = Object.Instantiate(ResourceLoader.LoadPrefab(_invenventoryPath), placeForUi, false);
            AddGameObjects(mainMenu);
            return mainMenu.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("StartGame");
        }
    }
}