using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : IInventoryModel
{
    private static readonly List<IItem> _emptyCollection = new List<IItem>();
    private readonly List<IItem> _items = new List<IItem>();

    private static readonly List<IAbility> _emptyAbilityCollection = new List<IAbility>();
    private readonly List<IAbility> _ability = new List<IAbility>();
    private readonly List<IItem> _abilityItem = new List<IItem>();

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _items ?? _emptyCollection;
    }

    public IReadOnlyList<IItem> GetEquippedAbilities()
    {
        return _abilityItem ?? _emptyCollection;
    }

    public void EquipItem(IItem item)
    {
        if (_items.Contains(item))
        {
            return;
        }
        _items.Add(item);
    }

    public void UnequipItem(IItem item)
    {
        if (!_items.Contains(item))
        {
            return;
        }
        _items.Remove(item);
    }

    public void EquipAbility(IAbility item)
    {
        if (_ability.Contains(item))
        {
            return;
        }
        _ability.Add(item);
    }

    public void UnequipAbility(IAbility item)
    {
        Debug.Log("Unequiped");
        if (!_ability.Contains(item))
        {
            return;
        }
        _ability.Remove(item);
    }

    public void AddAbilityItem(IItem item)
    {
        if (_abilityItem.Contains(item))
        {
            return;
        }
        _abilityItem.Add(item);
    }
}

