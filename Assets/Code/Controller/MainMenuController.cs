using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    internal class MainMenuController : BaseController
    {
        #region Fields
        
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/MainMenu" };
        private readonly ResourcePath _viewTrailRenderPath = new ResourcePath { PathResource = "Prefabs/BladeView" };
        private readonly ResourcePath _viewCarSpawnerPath = new ResourcePath { PathResource = "Prefabs/CarSpawner" };

        private ProfilePlayer _profilePlayer;
        private MainMenuView _view;

        #endregion


        #region ClassLifeCycles

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<MainMenuView>(placeForUi, _viewPath);
            _view.Init(StartGame);

            SubscriptionProperty<float> leftMove = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMove = new SubscriptionProperty<float>();

            var bladeView = LoadView<BladeView>(placeForUi, _viewTrailRenderPath);
            bladeView.Init(leftMove, rightMove, _profilePlayer.CurrentCar.Speed);

            var carSpawner = LoadView<BirdSpawner>(new GameObject("MainMenu").transform, _viewCarSpawnerPath);
            carSpawner.Init(leftMove, rightMove, _profilePlayer.CurrentCar.Speed);

        } 

        #endregion


        #region Methods

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("Start_Game");
        }

        private T LoadView<T>(Transform parrentPosition, ResourcePath viewPath) where T : Component
        {
            var view = Object.Instantiate(ResourceLoader.LoadPrefab(viewPath), parrentPosition, false);
            AddGameObjects(view);
            return view.GetComponent<T>();
        } 

        #endregion
    }
}