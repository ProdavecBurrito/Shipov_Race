using System.Collections.Generic;

public class UpgradeHandlersRepository : IRepository<int, IUpgradeHandler>
{
    private readonly Dictionary<int, IUpgradeHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeHandler>();
    public IReadOnlyDictionary<int, IUpgradeHandler> Collection => _upgradeItemsMapById;

    public UpgradeHandlersRepository(List<ItemUpgradeConfig> upgradeItemConfigs)
    {
        PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
    }

    private void PopulateItems( ref Dictionary<int, IUpgradeHandler> upgradeHandlersMapByType, List<ItemUpgradeConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.Id))
            {
                continue;
            }
            upgradeHandlersMapByType.Add(config.Id, CreateHandlerByType(config));
        }
    }

    private IUpgradeHandler CreateHandlerByType(ItemUpgradeConfig config)
    {
        switch (config.type)
        {
            case UpgradeType.Speed:
                return new SpeedUpgradeHandler(config.value);
            case UpgradeType.Ammo:
                return new AmmoUpgradeHandler((int)config.value);
            default:
                return StubUpgradeHandler.Default;
        }
    }
}
