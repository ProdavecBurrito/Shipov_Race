using System;
using System.Collections.Generic;
using JetBrains.Annotations;

public class InventoryController : BaseController, IInventoryController
{

    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryView;

    public InventoryController([NotNull] IInventoryModel inventoryModel, [NotNull] IItemsRepository itemsRepository, [NotNull] IInventoryView inventoryView)
    {
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
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

    }

    public void HideInventory()
    {

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


