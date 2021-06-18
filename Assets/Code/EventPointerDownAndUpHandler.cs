using UnityEngine;
using UnityEngine.EventSystems;


namespace JevLogin
{
    internal sealed class EventPointerDownAndUpHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public SubscriptionProperty<bool> IsButtonPressed = new SubscriptionProperty<bool>();

        public void OnPointerDown(PointerEventData eventData)
        {
            IsButtonPressed.Value = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsButtonPressed.Value = false;
        }
    }
}