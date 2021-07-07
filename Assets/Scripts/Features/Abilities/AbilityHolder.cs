using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    private Button _abilityButton;
    private IItem _abilityItem;

    public event EventHandler<IItem> UseRequested;

    public IItem AbilityItem { get => _abilityItem; set => _abilityItem = value; }
    public Button Button => _abilityButton;

    private void Awake()
    {
        _abilityButton = GetComponent<Button>();
    }

    public void Init()
    {
        if (_abilityItem == null)
        {
            _abilityButton.gameObject.SetActive(false);
        }
        else
        {
            _abilityButton.onClick.AddListener(TryUseAbility);
        }
    }

    private void TryUseAbility()
    {
        OnUseRequested(_abilityItem);
    }

    protected virtual void OnUseRequested(IItem e)
    {
        UseRequested?.Invoke(this, e);
    }
}