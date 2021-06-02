using UnityEngine;


namespace JevLogin
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        #region Fields

        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        protected float _speed;
        CarController _carController;

        #endregion


        #region ClassLifeCycles

        public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _speed = speed;
        }

        public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed, CarController carController) 
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _speed = speed;
            _carController = carController;
        }


        #endregion


        #region Methods

        protected virtual void OnLeftMove(float value)
        {
            _leftMove.Value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            _rightMove.Value = value;
        }

        #endregion
    }
}