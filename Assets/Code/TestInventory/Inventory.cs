using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal sealed class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemConfig> _items;
        [SerializeField] private InventoryCell _inventoryCellPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _draggingParent;

        private void OnEnable()
        {
            Render(_items);
        }

        private void Render(List<ItemConfig> items)
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }

            _items.ForEach(item =>
            {
                var cell = Instantiate(_inventoryCellPrefab, _container);
                cell.Init(_draggingParent);
                cell.Render(item);

                cell.Injecting += () => Destroy(cell.gameObject);
            });
        }
    }
}