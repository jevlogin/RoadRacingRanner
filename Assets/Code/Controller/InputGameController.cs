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

        #endregion


        #region ClassLifeCycles

        public InputGameController(SubscriptionProperty<float> leftMoveDiff, SubscriptionProperty<float> rightMoveDiff, Car currentCar)
        {
#if UNITY_ANDROID
            //_viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.MOBILESINGLESTICKCONTROL) };
            _viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.FLOATINPUTJOYSTICK) };
#endif
#if UNITY_EDITOR
            //_viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.ENDLESSMOVE) };
            _viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.FLOATINPUTJOYSTICK) };

#endif
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