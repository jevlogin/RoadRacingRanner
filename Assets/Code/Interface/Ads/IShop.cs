namespace JevLogin
{
    internal interface IShop
    {
        void Buy(string id);
        string GetCost(string productId);
        void RestorePurchase();
        IReadOnlySubscriptionAction OnSuccessPurchase { get; }
        IReadOnlySubscriptionAction OnFailePurchase { get; }
    }
}