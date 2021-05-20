using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace JevLogin
{
    internal class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        public event Action Injecting;

        [SerializeField] private TextMeshProUGUI _nameField;
        [SerializeField] private Image _iconImage;

        private Transform _draggingParent;
        private Transform _originalParent;

        public void Init(Transform draggingParent)
        {
            _draggingParent = draggingParent;
            _originalParent = transform.parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(_draggingParent);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (In((RectTransform)_originalParent, eventData))
            {
                InsertInGrid(); 
            }
            else
            {
                Inject();
            }
        }

        private bool In(RectTransform originalParent, PointerEventData eventData)
        {
            var res = originalParent.rect.Contains(transform.localPosition);
            return res;
        }

        private void Inject()
        {
            Injecting?.Invoke();
        }

        private void InsertInGrid()
        {
            int closestIndex = 0;
            for (int i = 0; i < _originalParent.transform.childCount; i++)
            {
                if (Vector3.Distance(transform.position, _originalParent.GetChild(i).position) <
                    Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
                {
                    closestIndex = i;
                }
            }

            transform.SetParent(_originalParent);
            transform.SetSiblingIndex(closestIndex);
        }

        public void Render(IItem item)
        {
            _nameField.text = item.Info.Name;
            _iconImage.sprite = item.Info.Image;
        }

        
    }
}