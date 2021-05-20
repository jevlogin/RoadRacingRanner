using System.Collections.Generic;


namespace JevLogin
{
    internal interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnequipItem(IItem item);
    }
}