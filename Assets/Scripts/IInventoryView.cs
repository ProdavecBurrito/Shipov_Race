using System.Collections.Generic;

public interface IInventoryView
{
    List<InventoryItem> InventoryItems { get; set; }

    void Display(List<IItem> items);
    void Show();
    void Hide();
}

