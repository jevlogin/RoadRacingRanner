using JoostenProductions;
using UnityEngine;


namespace JevLogin
{
    internal sealed class GyroscopeInputView : BaseInputView
    {
        #region ClassLifeCycles

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            Input.gyro.enabled = true;
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
            if (!SystemInfo.supportsGyroscope)
            {
                return;
            }

            Quaternion quaternion = Input.gyro.attitude;
            quaternion.Normalize();
            OnRightMove((quaternion.x + quaternion.y) * Time.deltaTime * _speed);
        }

        #endregion
    }
}