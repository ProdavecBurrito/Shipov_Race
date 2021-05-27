public class StubUpgradeHandler : IUpgradeHandler
{
    public static readonly IUpgradeHandler Default = new StubUpgradeHandler();

    public IUpgradable Upgrade(IUpgradable upgradable)
    {
        return upgradable;
    }
}
