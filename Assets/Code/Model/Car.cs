using System;

namespace JevLogin
{
    internal sealed class Car : IUpgradable, IDisposable
    {
        #region Fields

        private readonly float _defaultSpeed;

        #endregion


        #region Properties

        public SubscriptionProperty<float> SpeedProperty;
        public float Speed { get; set; }

        #endregion


        #region ClassLifeCycles

        public Car(float speed)
        {
            _defaultSpeed = speed;
            SpeedProperty = new SubscriptionProperty<float>();
            SpeedProperty.SubscriptionOnChange(ChangeSpeed);

            Restore();
        }

        private void ChangeSpeed(float value)
        {
            Speed = value;
        }

        #endregion


        #region IUpgradable

        public void Restore()
        {
            SpeedProperty.Value = _defaultSpeed;
        }

        public void Dispose()
        {
            SpeedProperty.UnSubscriptionOnChange(ChangeSpeed);
        }

        #endregion
    }
}