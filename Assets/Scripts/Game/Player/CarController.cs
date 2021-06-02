using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class CarController : BaseController, IAbilityActivator
    {
        private GameObject _carObject;
        private CarView _carView;
        private Transform CarPlaceForGun;

        public CarController(GameObject carObject)
        {
            _carObject = carObject;
            _carView = LoadView();
        }

        private CarView LoadView()
        {
            GameObject objView = Object.Instantiate(_carObject);
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