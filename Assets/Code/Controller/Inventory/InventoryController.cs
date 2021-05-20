using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal sealed class InventoryController : BaseController, IInventoryController
    {
        #region Fields

        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;

        #endregion


        #region ClassLifeCycles

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel, 
            [NotNull] IItemsRepository itemsRepository, 
            [NotNull] IInventoryView inventoryView)
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
        } 

        #endregion


        public void HideInventory()
        {

        }

        public void ShowInventory(Action callback)
        {
            
        }
    }
}