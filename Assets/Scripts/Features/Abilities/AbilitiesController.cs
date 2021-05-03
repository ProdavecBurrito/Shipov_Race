using JetBrains.Annotations;
using System;
using Tools;
using UnityEngine;

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
        FillInventory(_inventoryModel, _abilityRepository);
    }

    private void FillInventory(IInventoryModel inventoryModel, IRepository<int, IAbility> itemsRepository)
    {
        //for (int i = 0; i < itemsRepository.Collection.Count; i++)
        //{
        //    inventoryModel.EquipAbility(itemsRepository.Collection.Values);
        //    if (itemsRepository is AbilityRepository abilityRepository)
        //    {
        //        Debug.Log("B");
        //        inventoryModel.AddAbilityItem(abilityRepository.items[i]);
        //    }
        //}

        foreach (var item in itemsRepository.Collection.Values)
        {
            inventoryModel.EquipAbility(item);
            Debug.Log(item);
        }

        for (int i = 0; i < itemsRepository.Collection.Count; i++)
        {
            if (itemsRepository is AbilityRepository abilityRepository)
            {
                inventoryModel.AddAbilityItem(abilityRepository.items[i]);
            }
        }
    }

    private void SetupView(IAbilityCollectionView view)
    {
        for (int i = 0; i < view.AbilityItems.Count; i++)
        {
            view.AbilityItems[i].UseRequested += OnAbilityUseRequested;
        }
    }

    private void CleanupView(IAbilityCollectionView view)
    {
        for (int i = 0; i < view.AbilityItems.Count; i++)
        {
            view.AbilityItems[i].UseRequested -= OnAbilityUseRequested;
        }
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
        _abilityCollectionView.Display(_inventoryModel.GetEquippedAbilities());
    }

    public void EquipAbility()
    {

    }
}

