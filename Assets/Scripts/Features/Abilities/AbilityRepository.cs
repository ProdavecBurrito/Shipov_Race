using Profile;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRepository : IRepository<int, IAbility>
{
    private readonly Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();
    public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapById;
    public List<IItem> items = new List<IItem>();
    private readonly Car _car;
    private readonly Transform _gunPosition;

    public AbilityRepository(List<AbilityItemConfig> itemConfigs, Car car, Transform gunPosition)
    {
        _gunPosition = gunPosition;
        _car = car;
        PopulateItems(ref _abilityMapById, itemConfigs);
    }

    private void PopulateItems( ref Dictionary<int, IAbility> upgradeHandlersMapByType, List<AbilityItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.Id))
            {
                continue;
            }
            items.Add(CreateItem(config.itemConfig));
            upgradeHandlersMapByType.Add(config.Id, CreateAbilityByType(config, _car, _gunPosition));
        }
    }

    private IAbility CreateAbilityByType(AbilityItemConfig config, Car car, Transform gunPosition)
    {
        switch (config.type)
        {
            case AbilityType.Gun:
                return new GunAbility(config, car, gunPosition);
            case AbilityType.Shield:
                return new ShieldAbility(config);
            default:
                return StubAbility.Default;
        }
    }

    private IItem CreateItem(ItemConfig config)
    {
        return new Item
        {
            Id = config.id,
            Info = new ItemInfo { Title = config.title },
            Sprite = config.image
        };
    }
}
