using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private IItem _item;

    private Button _button;
    private bool _isEquipped;

    public event EventHandler<IItem> Selected;
    public event EventHandler<IItem> Deselected;

    public Button Button => _button;
    public IItem Item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
        }
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TryEquipItem);
    }

    private void TryEquipItem()
    {
        if (_isEquipped)
        {
            OnDeselected(_item);
            _isEquipped = false;
            _button.image.color = Color.white;
        }
        else
        {
            OnSelected(_item);
            _isEquipped = true;
            _button.image.color = Color.green;
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
