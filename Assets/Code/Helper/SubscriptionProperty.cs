using System;


namespace JevLogin
{
    internal sealed class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        #region Fields

        private T _value;
        private Action<T> _onChangeValue = delegate (T value) { };

        #endregion


        #region Properties

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                _onChangeValue.Invoke(_value);
            }
        }

        #endregion


        #region IReadOnlySubscriptionProperty

        public void SubscriptionOnChange(Action<T> subscriptionAction)
        {
            _onChangeValue += subscriptionAction;
        }

        public void UnSubscriptionOnChange(Action<T> unsubscription)
        {
            _onChangeValue -= unsubscription;
        }

        #endregion
    }
}