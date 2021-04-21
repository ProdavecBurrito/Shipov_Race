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
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();
            BackgroundController tapeBackgroundController = new BackgroundController(leftMoveDiff, rightMoveDiff);
            InputController inputGameController = new InputController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            CarController carController = new CarController();
            //AbilitiesController abilitiesController = new AbilitiesController(new Ab);

            AddController(inputGameController);
            AddController(tapeBackgroundController);
            AddController(carController);
        }
    }
}
