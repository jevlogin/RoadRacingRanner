using UnityEngine;


namespace JevLogin
{
    internal sealed class Item : IItem
    {
        [SerializeField] private int _id;
        [SerializeField] private ItemInfo _info;

        public int Id { get => _id; set => _id = value; }
        public ItemInfo Info { get => _info; set => _info = value; }
    }
}