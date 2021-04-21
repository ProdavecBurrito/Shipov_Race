using JetBrains.Annotations;
using Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShedController : BaseController
{
    private readonly Car _car;

    private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
    private readonly ItemsRepository _upgradeItemsRepository;
    private readonly InventoryModel _inventoryModel;
    private readonly InventoryController _inventoryController;
    private readonly IInventoryView _inventoryView;

    public ShedController( [NotNull] List<ItemUpgradeConfig> upgradeItemConfigs, [NotNull] Car car)
    {
        if (upgradeItemConfigs == null)
        {
            throw new ArgumentNullException(nameof(upgradeItemConfigs));
        }

        _car = car ?? throw new ArgumentNullException(nameof(car));
        _upgradeHandlersRepository = new UpgradeHandlersRepository(upgradeItemConfigs);
        _upgradeItemsRepository = new ItemsRepository(upgradeItemConfigs.Select(value => value.itemConfig).ToList());
        _inventoryModel = new InventoryModel();
        _inventoryController = new InventoryController(_inventoryModel, _upgradeItemsRepository, _inventoryView);

        AddController(_inventoryController);
        AddController(_upgradeItemsRepository);
        AddController(_upgradeHandlersRepository);
    }
    public void Enter()
    {
        _inventoryController.ShowInventory(Exit);
        Debug.Log($"Enter: car has speed : {_car.Speed}");
    }

    public void Exit()
    {
        UpgradeCarWithEquippedItems( _car, _inventoryModel.GetEquippedItems(), _upgradeHandlersRepository.UpgradeItems);
        Debug.Log($"Exit: car has speed : {_car.Speed}");
    }

    private void UpgradeCarWithEquippedItems(IUpgradableCar upgradableCar, IReadOnlyList<IItem> equippedItems, IReadOnlyDictionary<int, ICarUpgrade> upgradeHandlers)
    {
        foreach (var equippedItem in equippedItems)
        {
            if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
            {
                handler.Upgrade(upgradableCar);
            }
        }
    }

}

