using JetBrains.Annotations;
using System;
using UnityEngine;


namespace JevLogin
{
    internal sealed class InventoryController : BaseController, IInventoryController
    {
        #region Fields

        public event Action InventoryModelEquipped = delegate () { };

        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;
        private readonly ProfilePlayer _profilePlayer;

        #endregion


        #region ClassLifeCycles

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel, 
            [NotNull] IItemsRepository itemsRepository, 
            [NotNull] IInventoryView inventoryView,
            ProfilePlayer profilePlayer)
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
            _profilePlayer = profilePlayer;
            _inventoryView.Selected += _inventoryView_Selected;
            _inventoryView.Deselected += _inventoryView_Deselected;
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _inventoryView.Selected -= _inventoryView_Selected;
            _inventoryView.Deselected -= _inventoryView_Deselected;
        }

        private void _inventoryView_Deselected(object sender, IItem item)
        {
            _inventoryModel.UnequipItem(item);
            throw new NotImplementedException();
        }

        private void _inventoryView_Selected(object sender, IItem item)
        {
            _inventoryModel.EquipItem(item);
            Debug.Log($"Предмет использован! - {item.Info.Name}");

            InventoryModelEquipped.Invoke();
        }

        public void HideInventory()
        {
            throw new NotImplementedException();
        }

        public void ShowInventory(Action callback)
        {
            callback?.Invoke();
        }

        #endregion

    }
}