using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour, IInventoryView
{
    [SerializeField] private Button _closeButton;

    public event EventHandler<IItem> Selected;
    public event EventHandler<IItem> Deselected;
    private List<Image> _images;
    private Animator _animator;

    private List<IItem> _itemInfoCollection;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _images = GetComponentsInChildren<Image>().ToList();
    }

    public void CloseInventory(UnityAction unityAction)
    {
        _closeButton.onClick.AddListener(unityAction);
    }

    public void Show()
    {
        _animator.Play("Open");
    }

    public void Hide()
    {
        _animator.Play("Close");
    }

    public void Display(List<IItem> itemInfoCollection)
    {
        _itemInfoCollection = itemInfoCollection;
        Debug.Log(itemInfoCollection.Count);
        for (int i = 0; i < _itemInfoCollection.Count; i++)
        {
            _images[i].sprite = _itemInfoCollection[i].Sprite;
            Debug.Log(i);
        }
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

