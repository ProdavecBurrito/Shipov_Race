using JetBrains.Annotations;
using System;

public class AbilitiesController : BaseController, IAbilitiesController
{
    private readonly IRepository<int, IAbility> _abilityRepository;
    private readonly IInventoryModel _inventoryModel;
    private readonly IAbilityCollectionView _abilityCollectionView;
    private readonly IAbilityActivator _carController;

    public AbilitiesController([NotNull] IRepository<int, IAbility> abilityRepository, [NotNull] IInventoryModel inventoryModel,
           [NotNull] IAbilityCollectionView abilityCollectionView,
           [NotNull] IAbilityActivator abilityActivator)
    {
        _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _abilityCollectionView = abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView));
        _carController = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
        SetupView(_abilityCollectionView);
    }

    private void SetupView(IAbilityCollectionView view)
    {
        view.UseRequested += OnAbilityUseRequested;
    }

    private void CleanupView(IAbilityCollectionView view)
    {
        view.UseRequested -= OnAbilityUseRequested;
    }

    private void OnAbilityUseRequested(object sender, IItem e)
    {
        if (_abilityRepository.Collection.TryGetValue(e.Id, out var ability))
        {
            ability.Apply(_carController);
        }
    }

    public void ShowAbilities()
    {
        _abilityCollectionView.Show();
        _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
    }
}

