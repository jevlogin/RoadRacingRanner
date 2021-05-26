using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    internal sealed class InventoryController : BaseController, IInventoryController
    {
        #region Fields

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
        } 

        #endregion


        public void HideInventory()
        {

        }

        public void ShowInventory(Action callback)
        {
            
        }

        internal void Init()
        {
            _inventoryView.Display((_itemsRepository.Items.Values).ToList());
            _inventoryView.Selected += _inventoryView_Selected;
        }

        private void _inventoryView_Selected(object sender, IItem e)
        {
            Debug.Log($"Выбрасываю предмет {e.Id} - Name = {e.Info.Name}");
            if (_itemsRepository.Items.TryGetValue(e.Id, out var item))
            {
                if (item.Id == 1)
                {
                    _profilePlayer.CurrentCar.Speed += 1000;
                }
            }
        }
    }
}