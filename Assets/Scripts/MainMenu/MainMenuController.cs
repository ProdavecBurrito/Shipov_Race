using Profile;
using System.Linq;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _mainMenuPath = new ResourcePath { PathResource = "Prefabs/MainMenu" };
        private readonly ResourcePath _invenventoryPath = new ResourcePath { PathResource = "Prefabs/InventoryView" };
        private readonly PlayerProfile _playerProfile;
        private readonly InventoryController _inventoryController;
        private MainMenuView _view;
        private InventoryView _inventoryView;

        public MainMenuController(Transform placeForUi, Transform placeForInventory, PlayerProfile playerProfile)
        {
            _playerProfile = playerProfile;
            _view = ResourceLoader.LoadAndInstantiateObject<MainMenuView>(new ResourcePath { PathResource = "Prefabs/mainMenu" }, placeForUi, false);
            AddGameObjects(_view.gameObject);
            _view.Init(StartGame);

            var shedController = ConfigureShedController(placeForInventory, _playerProfile);
        }

        private ShedController ConfigureShedController( Transform placeForUi, PlayerProfile profilePlayer)
        {
            var upgradeItemsConfigCollection = ContentDataLoader.LoadUpgradeItemConfigs(new ResourcePath { PathResource = "Data/Upgrade/UpgradeItemConfigDataSource" });
            var upgradeItemsRepository = new UpgradeHandlersRepository(upgradeItemsConfigCollection);

            var itemsRepository = new ItemsRepository(upgradeItemsConfigCollection.Select(value => value.itemConfig).ToList());
            var inventoryModel = new InventoryModel();
            var inventoryViewPath = new ResourcePath { PathResource = $"Prefabs/{nameof(InventoryView)}" };
            var inventoryView = ResourceLoader.LoadAndInstantiateObject<InventoryView>(inventoryViewPath, placeForUi, false);
            AddGameObjects(inventoryView.gameObject);
            var inventoryController = new InventoryController(itemsRepository, inventoryModel, inventoryView);
            var shedController = new ShedController(upgradeItemsRepository, inventoryController, profilePlayer.CurrentCar);

            AddController(inventoryController);
            AddController(shedController);
            _view.OpenInventory(shedController.Enter);
            //inventoryView.CloseInventory(shedController.Exit);

            return shedController;
        }

        private void StartGame()
        {
            _playerProfile.CurrentState.Value = GameState.Game;
            _playerProfile.AnalyticTools.SendMessage("StartGame");
        }
    }
}