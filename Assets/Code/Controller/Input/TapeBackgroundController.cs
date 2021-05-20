using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    internal sealed class TapeBackgroundController : BaseController
    {
        #region Fields

        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = Path.Combine(ManagerPath.PREFABS, ManagerPath.BACKGROUND) };
        private readonly TapeBackgroundView _view;
        private readonly SubscriptionProperty<float> _diff;

        #endregion


        #region ClassLifeCycles

        public TapeBackgroundController(IReadOnlySubscriptionProperty<float> leftMoveDiff, IReadOnlySubscriptionProperty<float> rightMoveDiff)
        {
            _leftMove = leftMoveDiff;
            _rightMove = rightMoveDiff;
            _view = LoadView<TapeBackgroundView>(_viewPath);
            _diff = new SubscriptionProperty<float>();
            _view.Init(_diff);
            _leftMove.SubscriptionOnChange(Move);
            _rightMove.SubscriptionOnChange(Move);

        }

        #endregion


        #region Methods

        private void Move(float value)
        {
            _diff.Value = value;
        }

        private T LoadView<T>(ResourcePath viewPath)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(viewPath));
            AddGameObjects(objectView);
            return objectView.GetComponent<T>();
        }

        #endregion
    }
}