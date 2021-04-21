using System.Collections.Generic;

public class UpgradeHandlersRepository : BaseController
{
    public IReadOnlyDictionary<int, ICarUpgrade> UpgradeItems => _upgradeItemsMapById;
    private Dictionary<int, ICarUpgrade> _upgradeItemsMapById = new Dictionary<int, ICarUpgrade>();

    public UpgradeHandlersRepository( List<ItemUpgradeConfig> upgradeItemConfigs)
    {
        PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
    }

    private void PopulateItems( ref Dictionary<int, ICarUpgrade> upgradeHandlersMapByType, List<ItemUpgradeConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.Id)) continue;
            upgradeHandlersMapByType.Add(config.Id, CreateHandlerByType(config));
        }
    }

    private ICarUpgrade CreateHandlerByType(ItemUpgradeConfig config)
    {
        switch (config.type)
        {
            case UpgradeType.Speed:
                return new CarSpeedUpgrade(config.value);
            default:
                return CarStubUpgrade.Default;
        }
    }

    protected override void OnDispose()
    {
        _upgradeItemsMapById.Clear();
        _upgradeItemsMapById = null;
    }
}
