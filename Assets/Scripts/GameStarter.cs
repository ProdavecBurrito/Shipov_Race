﻿using Profile;
using UnityEngine;
using Profile.Analytic;
using System.Collections.Generic;

internal sealed class GameStarter : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private Transform _placeForInventory;
    [SerializeField] private Transform _placeForReward;
    [SerializeField] private float _speedCar;
    [SerializeField] private int _ammo;

    private MainRewardWindowController _mainRewardWindowController;
    private Camera _mainCamera;

    private MainController _mainController;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
        PlayerProfile profilePlayer = new PlayerProfile(_speedCar, _ammo, new UnityAnalyticTools());
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, _placeForInventory, _placeForReward, profilePlayer, _mainCamera);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
