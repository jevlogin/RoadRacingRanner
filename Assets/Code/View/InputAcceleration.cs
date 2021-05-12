using JoostenProductions;
using UnityEngine;


namespace JevLogin
{
    internal sealed class InputAcceleration : BaseInputView
    {
        #region Fields
        
        private Vector3 _direction = Vector3.zero; 

        #endregion


        #region ClassLifeCycles

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        #endregion


        #region Methods
        
        private void Move()
        {
            _direction = Vector3.zero;
            _direction.x = -Input.acceleration.y;
            _direction.z = Input.acceleration.x;

            if (_direction.sqrMagnitude > 1)
            {
                _direction.Normalize();
            }

            OnRightMove(_direction.sqrMagnitude / 20 * _speed);
        } 

        #endregion
    }
}