using UnityEngine;


namespace JevLogin
{
    internal class MainController : BaseController
    {
        #region Fields

        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;

        private MainMenuController _mainMenuController;
        private GameController _gameController;

        #endregion


        #region ClassLifeCycles

        public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            _profilePlayer.CurrentState.SubscriptionOnChange(OnChangeGameState);
        }

        #endregion


        #region Methods

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _gameController = new GameController(_placeForUi, _profilePlayer);
                    _mainMenuController?.Dispose();
                    break;
                default:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
            }
        }

        protected override void OnDispose()
        {
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
            _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
            base.OnDispose();
        }

        #endregion
    }
}