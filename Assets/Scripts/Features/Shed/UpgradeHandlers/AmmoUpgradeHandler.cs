internal class AmmoUpgradeHandler : IUpgradeHandler
{
    private int _ammo;

    public AmmoUpgradeHandler(int ammoValue)
    {
        _ammo = ammoValue;
    }

    public IUpgradable Upgrade(IUpgradable upgradable)
    {
        upgradable.Ammo = _ammo;
        return upgradable;
    }
}