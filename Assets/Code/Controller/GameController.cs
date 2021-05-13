using UnityEngine;

namespace JevLogin
{
    internal sealed class GameController : BaseController
    {
        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar, placeForUi);
            AddController(inputGameController);

            var carController = new CarController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(carController);
        }
    }
}