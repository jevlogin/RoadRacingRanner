using System.Collections.Generic;


namespace JevLogin
{
    internal sealed class ItemsRepository : BaseController, IItemsRepository
    {
        #region Fields
        
        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
        
        #endregion


        #region ClassLifeCycles

        public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _itemsMapById, upgradeItemConfigs);
        }

        protected override void OnDispose()
        {
            _itemsMapById.Clear();
            _itemsMapById = null;
        }

        private void PopulateItems(ref Dictionary<int, IItem> itemsMapById, List<ItemConfig> upgradeItemConfigs)
        {
            foreach (var config in upgradeItemConfigs)
            {
                if (itemsMapById.ContainsKey(config.Id))
                {
                    continue;
                }
                itemsMapById.Add(config.Id, CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                Id = config.Id,
                Info = new ItemInfo
                {
                    Name = config.Info.Name,
                    Image = config.Info.Image
                }
            };
        }

        #endregion
    }
}