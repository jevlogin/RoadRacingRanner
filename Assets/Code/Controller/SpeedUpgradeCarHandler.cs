namespace JevLogin
{
    internal class SpeedUpgradeCarHandler : IUpgradeCarHandler
    {
        private readonly float _speed;

        public SpeedUpgradeCarHandler(float speed)
        {
            _speed = speed;
        }

        public IUpgradable Upgrade(IUpgradable upgradableCar)
        {
            upgradableCar.Speed = _speed;
            return upgradableCar;
        }
    }
}