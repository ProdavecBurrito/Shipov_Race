using UnityEngine;

internal class SpeedUpgradeHandler : IUpgradeHandler
{
    private float _speed;

    public SpeedUpgradeHandler(float speedValue)
    {
        _speed = speedValue;
    }

    public IUpgradable Upgrade(IUpgradable upgradable)
    {
        Debug.Log($"Speed: { upgradable.Speed}");
        upgradable.Speed = _speed;
        Debug.Log($"Speed: { upgradable.Speed}");
        return upgradable;
    }
}