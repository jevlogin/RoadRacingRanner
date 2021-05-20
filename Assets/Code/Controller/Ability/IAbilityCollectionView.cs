using System;
using System.Collections.Generic;


namespace JevLogin
{
    internal interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}