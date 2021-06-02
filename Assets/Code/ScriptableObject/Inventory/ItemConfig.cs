using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Item", order = 51)]
    public sealed class ItemConfig : ScriptableObject, IItem
    {
        [SerializeField] private int _id;
        [SerializeField] private ItemInfo _info;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public ItemInfo Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info.Image = value.Image;
                _info.Name = value.Name;
            }
        }
    }
}