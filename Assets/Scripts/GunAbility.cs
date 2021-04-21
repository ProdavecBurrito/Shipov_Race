using JetBrains.Annotations;
using System;
using Tools;
using UnityEngine;

public class GunAbility : IAbility
{
    private readonly Rigidbody2D _viewPrefab;
    private readonly float _projectileSpeed;
    private readonly GameObject _gun;
    private readonly Transform _gunPosition;
    private readonly Transform _fireStartPos;

    public GunAbility([NotNull] string viewPath, float projectileSpeed, GunView gunView)
    {
        _viewPrefab = ResourceLoader.LoadObject<Rigidbody2D>(new ResourcePath { PathResource = viewPath });
        if (_viewPrefab == null)
        {
            throw new InvalidOperationException($"{nameof(GunAbility)} view requires {nameof(Rigidbody2D)} component!");
        }
        _gun = gunView.Gun;
        _gunPosition = gunView.Gun.transform;
        _fireStartPos = gunView._fireStartPos;
        _projectileSpeed = projectileSpeed;
    }

    public void Apply(IAbilityActivator activator)
    {
        var projectile = GameObject.Instantiate(_viewPrefab, _fireStartPos.position, _gun.transform.rotation);
        projectile.AddForce(activator.GetViewObject().transform.right * _projectileSpeed, ForceMode2D.Impulse);
    }
}

