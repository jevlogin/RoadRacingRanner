using System;


namespace JevLogin
{
    internal interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscriptionAction);
        void UnSubscribeOnChange(Action unSubscriptionAction);
    }
}