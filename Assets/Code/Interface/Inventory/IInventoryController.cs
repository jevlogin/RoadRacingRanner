using System;


namespace JevLogin
{
    internal interface IInventoryController
    {
        void ShowInventory(Action callback);
        void HideInventory();
    }
}