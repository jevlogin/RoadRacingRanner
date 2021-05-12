using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
//TODO IAbilityActivator


namespace JevLogin
{
    internal class CarController : BaseController
    {
        #region Fields

        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.CAR) };
        private GameObject _view;

        #endregion


        #region ClassLifeCycles

        public CarController(Car currentCar)
        {
            _view = LoadView<CarView>(_viewPath).gameObject;
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