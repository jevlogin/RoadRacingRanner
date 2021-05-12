namespace JevLogin
{
    internal sealed class ProfilePlayer
    {
        #region Properties

        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }

        #endregion


        #region ClassLifeCycles

        public ProfilePlayer(float speedCar, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = analyticTools;
        }

        #endregion
    }
}