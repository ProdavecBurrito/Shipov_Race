public class CarSpeedUpgrade : ICarUpgrade
{
    private readonly float _speed;

    public CarSpeedUpgrade(float speed)
    {
        _speed = speed;
    }

    public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
    {
        upgradableCar.Speed = _speed;
        return upgradableCar;
    }
}
