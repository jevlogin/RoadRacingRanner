using UnityEngine;


namespace JevLogin
{
    internal sealed class Root : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private Transform _placeForUi;
        [SerializeField] private float _speedCar = 15.0f;

        private MainController _mainController; 

        #endregion


        #region UnityMethods

        private void Awake()
        {
            ProfilePlayer profilePlayer = new ProfilePlayer(_speedCar, new UnityAnalyticTools());
            profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi, profilePlayer);
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
        } 

        #endregion
    }
}