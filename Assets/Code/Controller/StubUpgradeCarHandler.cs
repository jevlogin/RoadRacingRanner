namespace JevLogin
{
    internal class StubUpgradeCarHandler : IUpgradeCarHandler
    {
        public static readonly IUpgradeCarHandler Default = new StubUpgradeCarHandler();

        public IUpgradable Upgrade(IUpgradable upgradableCar)
        {
            return upgradableCar;
        }
    }
}