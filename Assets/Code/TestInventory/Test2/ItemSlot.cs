using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace JevLogin
{
    internal sealed class ItemSlot : MonoBehaviour, IDropHandler
    {
        private RectTransform _rectTransform;
        private RectTransform _rectTransformPointerDrag;
        public bool IsActiveSlot = false;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                _rectTransformPointerDrag = eventData.pointerDrag.GetComponent<RectTransform>();
                _rectTransformPointerDrag.SetParent(_rectTransform);
                _rectTransformPointerDrag.anchoredPosition = _rectTransform.anchoredPosition;
                _rectTransformPointerDrag.anchoredPosition = Vector2.zero;
            }
        }
    }
}