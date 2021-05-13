using JoostenProductions;
using UnityEngine;


namespace JevLogin
{
    internal sealed class InputJoystickView : BaseInputView
    {
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
            float moveStep = 10 * Time.deltaTime * Input.GetAxis(AxisManager.HORIZONTAL);
            if (moveStep > 0)
            {
                OnRightMove(moveStep);
            }
            else if (moveStep < 0)
            {
                OnLeftMove(moveStep);
            }
        }

        #endregion
    }
}