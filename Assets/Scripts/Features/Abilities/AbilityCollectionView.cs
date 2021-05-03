using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{
    public event EventHandler<IItem> UseRequested;

    private IReadOnlyList<IItem> _abilityItems;
    private List<Button> _buttons;
    private List<Image> _images;

    private void Awake()
    {
        _images = GetComponentsInChildren<Image>().ToList();
        Debug.Log(_images.Count);
    }

    protected virtual void OnUseRequested(IItem e)
    {
        UseRequested?.Invoke(this, e);
    }

    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        Debug.Log("Display");
        Debug.Log(abilityItems.Count);
        _abilityItems = abilityItems;
        for (int i = 0; i < _abilityItems.Count; i++)
        {
            _images[i].sprite = _abilityItems[i].Sprite;
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
