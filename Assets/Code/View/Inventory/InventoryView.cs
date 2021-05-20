using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    internal class InventoryView : MonoBehaviour, IInventoryView
    {
        #region Fields
        
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        [SerializeField] private Button _buttonViewShow;
        [SerializeField] private Button _buttonViewClose;

        private List<IItem> _itemInfoCollection; 

        #endregion


        #region IInventoryView

        public void Display(List<IItem> items)
        {
            _itemInfoCollection = items;
        } 

        #endregion


        #region Methods

        public void Show()
        {
            Debug.Log("Показываем инвентарь");
        }

        public void Hide()
        {
            Debug.Log("Прячем инвентарь");
        }

        protected virtual void OnSelected(IItem item)
        {
            Selected?.Invoke(this, item);
        }

        protected virtual void OnDeselected(IItem item)
        {
            Deselected?.Invoke(this, item);
        }

        #endregion
    }
}