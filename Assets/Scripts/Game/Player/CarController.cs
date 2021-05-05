﻿using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class CarController : BaseController, IAbilityActivator
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Car" };
        private CarView _carView;
        private Transform CarPlaceForGun;

        public CarController()
        {
           _carView = LoadView();
        }

        private CarView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            CarPlaceForGun = objView.GetComponentInChildren<Transform>().GetChild(0);
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }

        public Transform GetGunPosition()
        {
            return CarPlaceForGun;
        }
    }
}