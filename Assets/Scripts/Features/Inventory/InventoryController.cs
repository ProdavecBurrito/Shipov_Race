using JetBrains.Annotations;
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
        for (int i = 0; i < inventoryView.InventoryItems.Count; i++)
        {
            inventoryView.InventoryItems[i].Selected += OnItemSelected;
            inventoryView.InventoryItems[i].Deselected += OnItemDeselected;
        }
    }

    private void CleanupView()
    {
        for (int i = 0; i < _inventoryView.InventoryItems.Count; i++)
        {
            _inventoryView.InventoryItems[i].Selected += OnItemSelected;
            _inventoryView.InventoryItems[i].Deselected += OnItemDeselected;
        }
    }

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _inventoryModel.GetEquippedItems();
    }

    public void ShowInventory()
    {
        _inventoryView.ShowWindow();
        _inventoryView.Display(_itemsRepository.Collection.Values.ToList());
    }

    public void HideInventory()
    {
        _inventoryView.ShowWindow();
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


