using UnityEngine;

namespace JevLogin
{
    internal class SpeedUpgradeCarHandler : IUpgradeCarHandler
    {
        private readonly float _speed;

        public SpeedUpgradeCarHandler(float speed)
        {
            Debug.Log($"Speed Upgrade = {speed}/ Должно быть 100");
            _speed = speed;
        }

        public IUpgradable Upgrade(IUpgradable upgradableCar)
        {
            upgradableCar.Speed = _speed;
            Debug.Log($"Speed Машины = {upgradableCar.Speed}/ Должно быть 100");

            return upgradableCar;
        }
    }
}