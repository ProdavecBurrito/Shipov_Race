using Profile.Analytic;
using Tools;

namespace Profile
{
    internal class PlayerProfile
    {
        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }

        public IAnalyticTools AnalyticTools { get; }

        public PlayerProfile(float speedCar, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = analyticTools;
        }
    }
}


