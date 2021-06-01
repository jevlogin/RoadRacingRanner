using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace JevLogin
{
    [RequireComponent(typeof(Button))]
    internal sealed class ButtonScaleBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private ScaleData _pointerDownScale;
        [SerializeField] private ScaleData _pointerUpScale;

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerDownScale.Scale.x, _pointerDownScale.Scale.y, transform.localScale.z),
                _pointerDownScale.Duration).SetEase(_pointerDownScale.Ease);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerUpScale.Scale.x, _pointerUpScale.Scale.y, transform.localScale.z),
                _pointerUpScale.Duration).SetEase(_pointerUpScale.Ease);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerUpScale.Scale.x, _pointerUpScale.Scale.y, transform.localScale.z),
                _pointerUpScale.Duration).SetEase(_pointerUpScale.Ease);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        
    }
}