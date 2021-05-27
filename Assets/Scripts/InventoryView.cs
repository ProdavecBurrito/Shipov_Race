using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour, IInventoryView, ISidePanelTween
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private List<InventoryItem> _inventoryItems;
    [SerializeField] private Vector2 _openPosition;
    [SerializeField] private Vector2 _closePosition;

    private float _duration = 1.0f;
    private bool _isOpen;

    private List<IItem> _itemInfoCollection;

    public List<InventoryItem> InventoryItems { get => _inventoryItems; set => _inventoryItems = value; }

    public void CloseInventory(UnityAction unityAction)
    {
        _closeButton.onClick.AddListener(unityAction);
    }

    public void ShowWindow()
    {
        if (_isOpen)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        var sequence = DOTween.Sequence();

        sequence.Insert(0.0f, transform.DOLocalMove(_openPosition, _duration));
        sequence.OnComplete(() =>
        {
            sequence = null;
        });

        _isOpen = true;
    }

    private void Hide()
    {
        var sequence = DOTween.Sequence();

        sequence.Insert(0.0f, transform.DOLocalMove(_closePosition, _duration));
        sequence.OnComplete(() =>
        {
            sequence = null;
        });

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

