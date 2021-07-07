using Profile.Analytic;
using Tools;

namespace Profile
{
    internal class PlayerProfile
    {
        public IAnalyticTools AnalyticTools { get; }

        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }

        public PlayerProfile(float speedCar, int ammo, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar, ammo);
            AnalyticTools = analyticTools;
        }
    }
}


