using JetBrains.Annotations;
using Profile;
using Tools;
using UnityEngine;

public class GunAbility : IAbility
{
    private readonly AbilityItemConfig _config;
    private readonly Rigidbody2D _viewPrefab;
    private readonly GameObject _gun;
    //private readonly Transform _gunPosition;
    private readonly Transform _fireStartPos; 
    private readonly GunView _gunView;
    private readonly Car _car;

    public GunAbility([NotNull] AbilityItemConfig config, Car car)
    {
        var kek = GameObject.Instantiate<GameObject>(_gun);
        _config = config;
        _gunView = config.view.GetComponentInChildren<GunView>();
        _gun = _gunView.Gun;
        //_gunPosition = _gunView.Gun.transform;
        _fireStartPos = _gunView._fireStartPos;
        _viewPrefab = _gunView.FireObjects.GetComponent<Rigidbody2D>();
        _car = car;
    }

    public void Apply(IAbilityActivator activator)
    {
        if (_car.Ammo > 0)
        {
            var projectile = GameObject.Instantiate(_viewPrefab, _fireStartPos.position, _gun.transform.rotation);
            projectile.AddForce(activator.GetViewObject().transform.right * _config.value, ForceMode2D.Impulse);
        }
    }
  
}

