using JoostenProductions;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    internal sealed class FloatInputJoystick : BaseInputView
    {
        [SerializeField] private Button _buttonGaz;
        [SerializeField] private Button _buttonJump;
        [SerializeField] private float _forceJump;

        private bool _isGaz;
        private SubscriptionProperty<bool> _isButtonPressedProperty;
        [SerializeField] private Rigidbody2D _carViewRigidbody;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);

            if (_carViewRigidbody == null)
            {
                _carViewRigidbody = FindObjectOfType<CarView>().Rigidbody2D; 
            }

            _buttonJump.onClick.AddListener(JumpCar);

            _isButtonPressedProperty = _buttonGaz.GetComponent<TestEvents>().IsButtonPressed;
            _isButtonPressedProperty.SubscriptionOnChange(SwitchValue);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
            _buttonJump.onClick.RemoveListener(JumpCar);

            _isButtonPressedProperty.UnSubscriptionOnChange(SwitchValue);
        }
        private void JumpCar()
        {
            _carViewRigidbody.AddForce(Vector2.up * _speed * _forceJump, ForceMode2D.Impulse);
        }
       

        private void SwitchValue(bool value)
        {
            _isGaz = value;
        }

        private void Move()
        {
            if (_isGaz)
            {
                float moveStep = _speed * Time.deltaTime;
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
    }
}