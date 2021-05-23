using System;
using System.Collections.Generic;

public interface IAbilityCollectionView
{
    List<AbilityHolder> AbilityItems { get; set; }
    void Display(IReadOnlyList<IItem> abilityItems);
}