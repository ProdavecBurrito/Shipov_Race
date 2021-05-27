﻿using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IRepository<int, IItem> _itemsRepository;
    private readonly IInventoryView _inventoryView;
    private Action _hideAction;

    public InventoryController([NotNull] IRepository<int, IItem> itemsRepository, [NotNull] IInventoryModel inventoryModel, [NotNull] IInventoryView inventoryView)
    {
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));

        SetupView(_inventoryView);
    }

    private void SetupView(IInventoryView inventoryView)
    {
        inventoryView.Selected += OnItemSelected;
        inventoryView.Deselected += OnItemDeselected;
    }

    private void CleanupView()
    {
        _inventoryView.Selected -= OnItemSelected;
        _inventoryView.Deselected -= OnItemDeselected;
    }

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _inventoryModel.GetEquippedItems();
    }

    public void ShowInventory(Action hideAction)
    {
        _hideAction = hideAction;
        _inventoryView.Show();
        _inventoryView.Display(_itemsRepository.Collection.Values.ToList());
    }

    public void HideInventory()
    {
        _inventoryView.Hide();
        _hideAction?.Invoke();
    }

    private void OnItemSelected(object sender, IItem item)
    {
        _inventoryModel.EquipItem(item);
    }

    private void OnItemDeselected(object sender, IItem item)
    {
        _inventoryModel.UnequipItem(item);
    }

    protected override void OnDispose()
    {
        CleanupView();
        base.OnDispose();
    }
}


