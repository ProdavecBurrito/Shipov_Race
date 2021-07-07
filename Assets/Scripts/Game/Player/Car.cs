namespace Profile
{
    public class Car : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly int _defaultAmmo;

        public float Speed { get; set; }
        public int Ammo { get; set; }

        public Car(float speed, int ammo)
        {
            _defaultSpeed = speed;
            _defaultAmmo = ammo;
            Restore();
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
            Ammo = _defaultAmmo;
        }
    }

}
