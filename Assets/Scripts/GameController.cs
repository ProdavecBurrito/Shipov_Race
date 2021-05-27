using Game.InputLogic;
using Game.Background;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class GameController : BaseController
    {
        public GameController(Transform placeForUi, PlayerProfile profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var tapeBackgroundController = new BackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
            var inputGameController = new InputController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);
            var carController = new CarController();
            AddController(carController);

            var abilityController = ConfigureAbilityController(placeForUi, carController);
        }

        private IAbilitiesController ConfigureAbilityController(Transform placeForUi, IAbilityActivator abilityActivator)
        {
            var abilityItemsConfigCollection = ContentDataLoader.LoadAbilityItemConfigs(new ResourcePath { PathResource = "DataSource/Ability/AbilityItemConfigDataSource" });
            var abilityRepository = new AbilityRepository(abilityItemsConfigCollection);
            var abilityCollectionViewPath = new ResourcePath { PathResource = $"Prefabs/{nameof(AbilityCollectionView)}" };
            var abilityCollectionView = ResourceLoader.LoadAndInstantiateObject<AbilityCollectionView>(abilityCollectionViewPath, placeForUi, false);
            AddGameObjects(abilityCollectionView.gameObject);

            var inventoryModel = new InventoryModel();
            var abilitiesController = new AbilitiesController(abilityRepository, inventoryModel, abilityCollectionView, abilityActivator);
            AddController(abilitiesController);

            return abilitiesController;
        }
    }
}
