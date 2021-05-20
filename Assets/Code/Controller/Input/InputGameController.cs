using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    internal class InputGameController : BaseController
    {
        #region Fields

        private readonly ResourcePath _viewPath;
        private BaseInputView _view;
        private CarController _carView;

        #endregion


        #region ClassLifeCycles

        public InputGameController(SubscriptionProperty<float> leftMoveDiff, 
            SubscriptionProperty<float> rightMoveDiff, Car currentCar, CarController carView)
        {
            _carView = carView;
            _viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.FLOATINPUTJOYSTICK) };
            _view = LoadView<BaseInputView>(_viewPath);
            _view.Init(leftMoveDiff, rightMoveDiff, currentCar.Speed);
        }

        #endregion


        #region Methods

        private T LoadView<T>(ResourcePath _viewPath)
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<T>();
        }

        #endregion
    }
}