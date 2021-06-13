using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace JevLogin
{
    internal sealed class ItemDragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private Canvas _canvas;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        public TextMeshProUGUI Name;
        public Image Image;
        public bool IsActiveSlot;
        private IItem _item;
        public event EventHandler<IItem> ActivateItem = delegate (object sender, IItem item) { };


        private void Awake()
        {
            _canvas = transform.gameObject.GetComponentInParent<Canvas>();
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
        }


        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            if (!eventData.pointerDrag.TryGetComponent<ItemSlot>(out var itemSlot))
            {
                _rectTransform.anchoredPosition = Vector3.zero;
            }
            if (_rectTransform.parent.TryGetComponent<ItemSlot>(out var itemslot2))
            {
                IsActiveSlot = itemslot2.IsActiveSlot;
            }

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _canvasGroup.alpha = 0.5f;
        }

        internal void SendItem(IItem item)
        {
            _item = item;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _canvasGroup.alpha = 1.0f;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsActiveSlot)
            {
                ActivateItem.Invoke(this, _item);
            }
        }
    }
}