using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    internal sealed class ShedController : BaseController, IShedController
    {
        #region Fields

        private readonly Car _car;
        private readonly UpgradeHandlerRepository _upgradeHandlerRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryController _inventoryController;

        #endregion


        #region ClassLifeCycles

        public ShedController(
            [NotNull] List<UpgradeItemConfig> upgradeItemConfigs,
            [NotNull] Car car, [NotNull] InventoryController inventoryController, InventoryModel inventoryModel)
        {
            if (upgradeItemConfigs == null)
            {
                throw new System.ArgumentNullException(nameof(upgradeItemConfigs));
            }
            _car = car ?? throw new System.ArgumentNullException(nameof(car));

            _upgradeHandlerRepository = new UpgradeHandlerRepository(upgradeItemConfigs);
            AddController(_upgradeHandlerRepository);

            _upgradeItemsRepository = new ItemsRepository(upgradeItemConfigs.Select(value => value.ItemConfig).ToList());
            AddController(_upgradeItemsRepository);

            _inventoryModel = inventoryModel;

            _inventoryController = inventoryController;
            _inventoryController.InventoryModelEquipped += Enter;
            AddController(_inventoryController);
        }

        #endregion


        #region IShedController

        public void Enter()
        {
            _inventoryController.ShowInventory(Exit);
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(_car, _inventoryModel.GetEquippedItems(), _upgradeHandlerRepository.UpgradeItems);
            _car.SpeedProperty.Value = _car.Speed;
        }

       

        private void UpgradeCarWithEquippedItems(IUpgradable car, IReadOnlyList<IItem> items, IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeItems)
        {
            foreach (var equippedItem in items)
            {
                if (upgradeItems.TryGetValue(equippedItem.Id, out var handler))
                {
                    handler.Upgrade(car);
                }
            }
        }

        #endregion
    }
}