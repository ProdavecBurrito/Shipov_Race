using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ShedController : BaseController
{
    private readonly IUpgradable _upgradable;

    private readonly IRepository<int, IUpgradeHandler> _upgradeHandlersRepository;
    private readonly IInventoryController _inventoryController;
    private bool _isOpen;


    public ShedController([NotNull] IRepository<int, IUpgradeHandler> upgradeHandlersRepository, [NotNull] IInventoryController inventoryController, [NotNull] IUpgradable upgradable)
    {
        _isOpen = false;
        _upgradeHandlersRepository = upgradeHandlersRepository ?? throw new ArgumentNullException(nameof(upgradeHandlersRepository));

        _inventoryController = inventoryController ?? throw new ArgumentNullException(nameof(inventoryController)); ;

        _upgradable = upgradable ?? throw new ArgumentNullException(nameof(upgradable));
    }

    public void ShowWindow()
    {
        if (!_isOpen)
        {
            Enter();
        }
        else
        {
            Exit();
        }
    }

    private void Enter()
    {
        _inventoryController.ShowInventory();
        _isOpen = true;
    }

    private void Exit()
    {
        _inventoryController.HideInventory();
        _isOpen = false;
        UpgradeCarWithEquippedItems(_upgradable, _inventoryController.GetEquippedItems(), _upgradeHandlersRepository.Collection);
    }

    private void UpgradeCarWithEquippedItems(IUpgradable upgradable, IReadOnlyList<IItem> equippedItems, IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers)
    {
        foreach (var equippedItem in equippedItems)
        {
            if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
            {
                handler.Upgrade(upgradable);
            }
        }
    }

}

