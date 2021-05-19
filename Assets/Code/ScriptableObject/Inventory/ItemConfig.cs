using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Item", order = 51)]
    internal sealed class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private ItemInfo _info;

        public int Id => _id;
        public ItemInfo Info => _info;
    }
}