using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour, IInventoryView
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private List<InventoryItem> _inventoryItems;

    private Animator _animator;
    private bool _isOpen;

    private List<IItem> _itemInfoCollection;

    public List<InventoryItem> InventoryItems { get => _inventoryItems; set => _inventoryItems = value; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void CloseInventory(UnityAction unityAction)
    {
        _closeButton.onClick.AddListener(unityAction);
    }

    public void Show()
    {
        if (!_isOpen)
        {
            _animator.Play("Open");
            _isOpen = true;
        }
    }

    public void Hide()
    {
        _animator.Play("Close");
        _isOpen = false;
    }

    public void Display(List<IItem> itemInfoCollection)
    {
        _itemInfoCollection = itemInfoCollection;
        Debug.Log(itemInfoCollection.Count);
        for (int i = 0; i < _inventoryItems.Count; i++)
        {
            _inventoryItems[i].Button.image.sprite = _itemInfoCollection[i].Sprite;
            _inventoryItems[i].Item = _itemInfoCollection[i];
            Debug.Log(i);
        }
    }
}

