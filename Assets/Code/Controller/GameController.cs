using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    internal sealed class GameController : BaseController
    {
        private IInventoryView _inventoryView;
        private List<UpgradeItemConfig> _upgradeItemsConfigCollection = new List<UpgradeItemConfig>();
        private List<ItemConfig> _itemsConfigs = new List<ItemConfig>();
        private InventoryModel _inventoryModel;

        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var carController = new CarController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(carController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar, carController);
            AddController(inputGameController);


            var inventory = ResourceLoader.LoadObject<InventoryView>(new ResourcePath() { PathResource = "Prefabs/UI/InventoryGroup" });
            if (inventory != null)
            {
                _inventoryView = Object.Instantiate(inventory, placeForUi);
            }
            _inventoryModel = new InventoryModel();

            List<UpgradeItemConfig> itemConfigData = ContentDataSourceLoader.LoadUpgradeItemConfigs(new ResourcePath { PathResource = "Data/Upgrade/UpgradeItemConfigDataSource" });


            ItemsRepository itemsRepository = new ItemsRepository(itemConfigData.Select(value => value.ItemConfig).ToList());

            _inventoryView.Display(itemsRepository.Items.Values.ToList());

            var inventoryController = new InventoryController(_inventoryModel, itemsRepository, _inventoryView, profilePlayer);

            var shedController = new ShedController(itemConfigData, profilePlayer.CurrentCar, inventoryController, _inventoryModel);
            AddController(shedController);

        }
    }
}