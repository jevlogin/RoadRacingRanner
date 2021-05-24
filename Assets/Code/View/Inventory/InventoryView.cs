using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    internal class InventoryView : MonoBehaviour, IInventoryView
    {
        #region Fields

        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        [SerializeField] private Transform InventorySlot;

        [SerializeField] private Button _buttonViewShow;
        [SerializeField] private Button _buttonViewClose;
        [SerializeField] private GameObject _inventoryPanel;


        private List<IItem> _itemInfoCollection;

        #endregion

        private void OnEnable()
        {
            _buttonViewClose.onClick.AddListener(Hide);
            _buttonViewShow.onClick.AddListener(Show);
        }



        private void OnDisable()
        {
            _buttonViewClose.onClick.RemoveListener(Hide);
            _buttonViewShow.onClick.RemoveListener(Show);
        }

        #region IInventoryView

        public void Display(List<IItem> items)
        {
            _itemInfoCollection = items;
            var cell = InventorySlot.GetComponentsInChildren<InventoryCell>().ToList();

            if (_itemInfoCollection != null)
            {
                for (int i = 0; i < _itemInfoCollection.Count; i++)
                {
                    cell[i].Init(_inventoryPanel.transform);
                    cell[i].Render(_itemInfoCollection[i]);
                }
            }
        }

        #endregion


        #region Methods

        public void Show()
        {
            _inventoryPanel.SetActive(true);
            _buttonViewShow.interactable = false;
            Pause(true);
        }

        public void Hide()
        {
            _inventoryPanel.SetActive(false);
            _buttonViewShow.interactable = true;
            Pause(false);
        }

        private void Pause(bool value)
        {
            if (value)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
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