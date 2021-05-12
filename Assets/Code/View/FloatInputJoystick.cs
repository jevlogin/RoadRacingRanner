using JoostenProductions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;


namespace JevLogin
{
    internal sealed class FloatInputJoystick : BaseInputView, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private CanvasGroup _container;

        private bool _usedJoystick;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            //_usedJoystick = true;
            UpdateManager.SubscribeToUpdate(Move);
        }


        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            if (_usedJoystick)
            {
                float moveStep = _speed * Time.deltaTime * CrossPlatformInputManager.GetAxis(AxisManager.HORIZONTAL);
                if (moveStep > 0)
                {
                    OnRightMove(moveStep);
                }
                else if (moveStep < 0)
                {
                    OnLeftMove(moveStep);
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log($"OnDrag");

            _joystick.OnDrag(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log($"OnPointerDown");
            _joystick.transform.position = eventData.position;
            _joystick.SetStartPosition(eventData.position);
            _joystick.OnPointerDown(eventData);
            _usedJoystick = true;
            _container.alpha = 1;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log($"OnPointerUp");

            _usedJoystick = false;
            _container.alpha = 0;
        }
    }
}