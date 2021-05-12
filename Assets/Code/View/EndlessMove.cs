using JoostenProductions;
using UnityEngine;


namespace JevLogin
{
    internal sealed class EndlessMove : BaseInputView
    {
        #region ClassLifeCycles

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(MoveToRight);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(MoveToRight);
        }

        #endregion


        #region Methods

        private void MoveToRight()
        {
            OnRightMove(_speed * Time.deltaTime);
        } 

        #endregion
    }
}