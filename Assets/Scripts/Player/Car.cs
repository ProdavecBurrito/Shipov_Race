namespace Profile
{
    public class Car : IUpgradable
    {
        private readonly float _defaultSpeed;

        public float Speed { get; set; }

        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }

}
