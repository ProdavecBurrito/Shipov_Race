using JetBrains.Annotations;
using System;
using Tools;
using UnityEngine;

public class GunAbility : IAbility
{
    private readonly AbilityItemConfig _config;
    private readonly Rigidbody2D _viewPrefab;
    private readonly GameObject _gun;
    private readonly Transform _gunPosition;
    private readonly Transform _fireStartPos;
    private readonly GunView _gunView;
    public GunAbility([NotNull] AbilityItemConfig config)
    {
        _config = config;
        _gunView = config.view.GetComponent<GunView>();
        _gun = _gunView.Gun;
        _gunPosition = _gunView.Gun.transform;
        _fireStartPos = _gunView._fireStartPos;
        _viewPrefab = _gunView.FireObjects.GetComponent<Rigidbody2D>();
    }

    public void Apply(IAbilityActivator activator)
    {
        var projectile = GameObject.Instantiate(_viewPrefab, _fireStartPos.position, _gun.transform.rotation);
        projectile.AddForce(activator.GetViewObject().transform.right * _config.value, ForceMode2D.Impulse);
    }
  
}

