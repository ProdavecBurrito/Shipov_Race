﻿using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class MainMenuController : BaseController
    {

        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/MainMenu" };
        private readonly PlayerProfile _profilePlayer;
        private MainMenuView _view;

        public MainMenuController(Transform placeForUi, PlayerProfile profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("StartGame");
        }
    }
}