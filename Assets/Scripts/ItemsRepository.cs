using System.Collections.Generic;

public class ItemsRepository : BaseController, IItemsRepository
{
    public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

    public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
    {
        PopulateItems(ref _itemsMapById, upgradeItemConfigs);
    }

    private void PopulateItems(ref Dictionary<int, IItem> upgradeHandlersMapByType, List<ItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.id))
            {
                continue;
            }
            upgradeHandlersMapByType.Add(config.id, CreateItem(config));
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

    protected override void OnDispose()
    {
        base.Dispose();
        _itemsMapById.Clear();
        _itemsMapById = null;
    }
}

