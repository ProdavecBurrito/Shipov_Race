internal class SpeedUpgradeHandler : IUpgradeHandler
{
    private float _speed;

    public SpeedUpgradeHandler(float speedValue)
    {
        _speed = speedValue;
    }

    public IUpgradable Upgrade(IUpgradable upgradable)
    {
        upgradable.Speed = _speed;
        return upgradable;
    }
}