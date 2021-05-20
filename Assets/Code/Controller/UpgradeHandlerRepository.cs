using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal sealed class UpgradeHandlerRepository : BaseController
    {
        #region Fields

        private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();

        public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;

        #endregion


        #region ClassLifeCycles

        public UpgradeHandlerRepository(List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
        }

        private void PopulateItems(ref Dictionary<int, IUpgradeCarHandler> upgradeItemsMapById, List<UpgradeItemConfig> upgradeItemConfigs)
        {
            foreach (var config in upgradeItemConfigs)
            {
                if (upgradeItemsMapById.ContainsKey(config.Id))
                {
                    continue;
                }
                upgradeItemsMapById.Add(config.Id, CreateHandlerByType(config));
            }
        }

        private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.Type)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeCarHandler(config.ValueUpgrade);
                default:
                    return StubUpgradeCarHandler.Default;
            }
        }

        #endregion
    }
}