namespace JevLogin
{
    internal sealed class Car : IUpgradable
    {
        #region Fields

        private readonly float _defaultSpeed;

        #endregion


        #region Properties

        public float Speed { get; set; }

        #endregion


        #region ClassLifeCycles

        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        #endregion


        #region IUpgradable

        public void Restore()
        {
            Speed = _defaultSpeed;
        }

        #endregion
    }
}