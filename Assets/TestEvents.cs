using UnityEngine;
using UnityEngine.EventSystems;


namespace JevLogin
{
    internal sealed class TestEvents : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler
    {
        public bool IsButtonPressed;

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");

            //if (Input.touchCount > 0)
            //{
            //    transform.localScale *= 1.1f;
            //}

            IsButtonPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("OnPointerUp");
            IsButtonPressed = false;
        }
    }
}