using System.Collections.Generic;


namespace JevLogin
{
    internal sealed class InventoryModel : IInventoryModel
    {
        #region Fields

        private static readonly List<IItem> _emptyCollection = new List<IItem>();
        private readonly List<IItem> _equippedItems = new List<IItem>();

        #endregion


        #region IInventoryModel

        public void EquipItem(IItem item)
        {
            if (_equippedItems.Contains(item))
            {
                return;
            }
            _equippedItems.Add(item);
        }

        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _equippedItems ?? _emptyCollection;
        }

        public void UnequipItem(IItem item)
        {
            if (!_equippedItems.Contains(item))
            {
                return;
            }
            _equippedItems.Remove(item);
        } 

        #endregion
    }
}