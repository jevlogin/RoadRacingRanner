using JoostenProductions;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
//TODO IAbilityActivator


namespace JevLogin
{
    internal class CarController : BaseController, IAbilityActivator
    {
        #region Fields

        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.CAR) };
        private readonly SubscriptionProperty<float> _leftMoveDiff;
        private readonly SubscriptionProperty<float> _rightMoveDiff;
        private CarView _carView;
        #endregion


        #region ClassLifeCycles

        public CarController(SubscriptionProperty<float> leftMoveDiff, SubscriptionProperty<float> rightMoveDiff, Car currentCar)
        {
            _carView = LoadView<CarView>(_viewPath);
            _leftMoveDiff = leftMoveDiff;
            _rightMoveDiff = rightMoveDiff;
        }

        public GameObject GetViewObject()
        {
            throw new System.NotImplementedException();
        }


        #endregion


        #region Methods

        private T LoadView<T>(ResourcePath viewPath)
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(viewPath));
            AddGameObjects(objectView);
            return objectView.GetComponent<T>();
        }

        #endregion
    }
}