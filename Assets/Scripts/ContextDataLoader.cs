using System.Collections.Generic;
using System.Linq;
using Tools;

public static class ContentDataLoader
{
    public static List<ItemUpgradeConfig> LoadUpgradeItemConfigs(ResourcePath resourcePath)
    {
        var config = ResourceLoader.LoadObject<ItemUpgradeConfigDataSource>(resourcePath);
        return config == null ? new List<ItemUpgradeConfig>() : config.itemConfigs.ToList();
    }

    public static List<AbilityItemConfig> LoadAbilityItemConfigs(ResourcePath resourcePath)
    {
        var config = ResourceLoader.LoadObject<AbilityItemConfigDataSource>(resourcePath);
        return config == null ? new List<AbilityItemConfig>() : config.itemConfigs.ToList();
    }
}
