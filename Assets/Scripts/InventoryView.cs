using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour, IInventoryView
{
    [SerializeField] private Button _closeInventory;
    public event EventHandler<IItem> Selected;
    public event EventHandler<IItem> Deselected;

    private Animator _animator;

    private List<IItem> _itemInfoCollection;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenInventory()
    {
        _animator.Play("OpenAnimation");
    }

    public void CloseInventory()
    {
        _animator.Play("CloseAnimation");
    }

    public void Show()
    {
        _animator.Play("OpenAnimation");
    }

    public void Hide()
    {
        _closeInventory.onClick.AddListener(CloseInventory);
    }

    public void Display(List<IItem> itemInfoCollection)
    {
        _itemInfoCollection = itemInfoCollection;
    }

    protected virtual void OnSelected(IItem e)
    {
        Selected?.Invoke(this, e);
    }

    protected virtual void OnDeselected(IItem e)
    {
        Deselected?.Invoke(this, e);
    }
}

