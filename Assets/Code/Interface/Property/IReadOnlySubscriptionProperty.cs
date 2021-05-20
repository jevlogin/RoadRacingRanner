using System;


namespace JevLogin
{
    internal interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }
        void SubscriptionOnChange(Action<T> subscriptionAction);
        void UnSubscriptionOnChange(Action<T> unsubscription);
    }
}