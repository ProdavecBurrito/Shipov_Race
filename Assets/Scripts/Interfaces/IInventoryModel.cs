using System.Collections.Generic;

public interface IInventoryModel
{
    IReadOnlyList<IItem> GetEquippedItems();
    IReadOnlyList<IItem> GetEquippedAbilities();
    void EquipItem(IItem item);
    void UnequipItem(IItem item);
    void EquipAbility(IAbility item);
    void UnequipAbility(IAbility item);
    void AddAbilityItem(IItem item);
}

