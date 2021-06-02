using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace JevLogin
{
    internal sealed class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        public event Action<IItem> Injecting;

        [SerializeField] private TextMeshProUGUI _nameField;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Button _removeButton;
        [SerializeField] private Button _itemButton;

        private Transform _draggingParent;
        private Transform _originalParent;
        private IItem _item;

        public void Init(Transform draggingParent)
        {
            _draggingParent = draggingParent;
            _originalParent = transform.parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_itemButton.interactable)
            {
                transform.SetParent(_draggingParent); 
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_itemButton.interactable)
            {
                transform.position = Input.mousePosition;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_itemButton.interactable)
            {
                if (In((RectTransform)_originalParent, eventData))
                {
                    InsertInGrid();
                }
                else
                {
                    Inject(_item);
                } 
            }
        }

        private bool In(RectTransform originalParent, PointerEventData eventData)
        {
            var res = originalParent.rect.Contains(eventData.position);
            return res;
        }

        private void Inject(IItem _item)
        {
            Injecting?.Invoke(_item);
            Destroy(gameObject);
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
            _item = item;
            _nameField.text = item.Info.Name;
            _iconImage.sprite = item.Info.Image;
            _iconImage.enabled = true;
            _iconImage.transform.parent.GetComponent<Button>().interactable = true;
            _removeButton.interactable = true;
        }
    }
}