using System;
using System.Collections.Generic;

public interface IInventoryController
{
    IReadOnlyList<IItem> GetEquippedItems();
    void ShowInventory();
    void HideInventory();
}

