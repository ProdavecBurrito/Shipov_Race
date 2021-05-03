using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{

    [SerializeField] private List<AbilityHolder> _abilityItems;

    private IReadOnlyList<IItem> _itemInfoCollection;

    public List<AbilityHolder> AbilityItems { get => _abilityItems; set => _abilityItems = value; }

    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        _itemInfoCollection = abilityItems;
        for (int i = 0; i < _itemInfoCollection.Count; i++)
        {
            _abilityItems[i].Button.image.sprite = _itemInfoCollection[i].Sprite;
            _abilityItems[i].AbilityItem = _itemInfoCollection[i];
        }

        for (int i = 0; i < _abilityItems.Count; i++)
        {
            Show(_abilityItems[i]);
        }
    }

    public void Show(AbilityHolder abilityHolder)
    {
        abilityHolder.Init();
    }

    public void Hide()
    {
    }

}
