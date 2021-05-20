using System;
using System.Collections.Generic;


namespace JevLogin
{
    internal interface IInventoryView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> items);
    }
}