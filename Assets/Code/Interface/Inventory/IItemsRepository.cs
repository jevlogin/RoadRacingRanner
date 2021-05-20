using System.Collections.Generic;


namespace JevLogin
{
    internal interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}