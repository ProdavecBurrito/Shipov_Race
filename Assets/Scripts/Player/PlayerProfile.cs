using Tools;

namespace Profile
{
    internal class PlayerProfile
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }

        public PlayerProfile(float carSpeed)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(carSpeed);
        }
    }
}


