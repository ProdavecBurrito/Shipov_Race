using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{
    private IReadOnlyList<IItem> _abilityItems;
    private List<Button> _buttons;

    protected virtual void OnUseRequested(IItem e)
    {
        UseRequested?.Invoke(this, e);
        _buttons = GetComponentsInChildren<Button>().ToList();
    }

    public event EventHandler<IItem> UseRequested;

    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        _abilityItems = abilityItems;
        for (int i = 0; i < _abilityItems.Count; i++)
        {
            _buttons[i].image.sprite = _abilityItems[i].Sprite;
            Debug.Log(i);
        }
    }

    public void Show()
    {
    }

    public void Hide()
    {
    }

}
