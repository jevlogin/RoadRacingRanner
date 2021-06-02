using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace JevLogin
{
    internal sealed class DragDrop : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log($"OnPointerDown");
        }
    }
}