using JetBrains.Annotations;
using Profile;
using Tools;
using UnityEngine;

public class GunAbility : IAbility
{
    private readonly AbilityItemConfig _config;
    private readonly Rigidbody2D _viewPrefab;
    private readonly GameObject _gun;
    private readonly Transform _fireStartPos; 
    private readonly GunView _gunView;
    private readonly Car _car;

    public GunAbility([NotNull] AbilityItemConfig config, Car car, Transform gunPosition)
    {
        _config = config;
        var gunBase = GameObject.Instantiate<GameObject>(_config.view, gunPosition);
        _gunView = gunBase.GetComponentInChildren<GunView>();
        _gun = _gunView.Gun;
        Debug.Log(_gun);
        _fireStartPos = _gunView._fireStartPos;
        Debug.Log(_fireStartPos);
        _viewPrefab = _gunView.FireObjects.GetComponent<Rigidbody2D>();
        Debug.Log(_viewPrefab);
        _car = car;
    }

    public void Apply(IAbilityActivator activator)
    {
        if (_car.Ammo > 0)
        {
            var projectile = GameObject.Instantiate(_viewPrefab, _fireStartPos.position, _gun.transform.rotation);
            projectile.AddForce(Vector2.right * _config.value, ForceMode2D.Impulse);
        }
    }
  
}

