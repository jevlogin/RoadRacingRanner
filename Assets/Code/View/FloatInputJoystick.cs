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
        [SerializeField] private Rigidbody2D _carViewRigidbody;

        private SubscriptionProperty<bool> _isButtonPressedProperty;
        private bool _isGaz;
        [SerializeField] private JointMotor2D _motor2DBack;
        [SerializeField] private JointMotor2D _motor2DForward;
        [SerializeField] private float _speedMotor;
        private bool _activateSpeedMotor;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);

            if (_carViewRigidbody == null)
            {
                var car = FindObjectOfType<CarView>();
                _carViewRigidbody = car.Rigidbody2D;
                _motor2DBack = car.WheelJoint2DBack.motor;
                _motor2DForward = car.WheelJoint2DForward.motor;
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
                if (!_activateSpeedMotor)
                {
                    RunMotorWheel();
                }
            }
            else if (_activateSpeedMotor)
            {
                StopMotorWheel();
            }
        }

        private void StopMotorWheel()
        {
            _activateSpeedMotor = false;
            _motor2DBack.motorSpeed = 0.0f;
            _motor2DForward.motorSpeed = 0.0f;
        }

        private void RunMotorWheel()
        {
            _activateSpeedMotor = true;
            _motor2DBack.motorSpeed = _speedMotor;
            _motor2DForward.motorSpeed = _speedMotor;

            Debug.Log($"RunMotorWheel - _motor2DBack.motorSpeed = {_motor2DBack.motorSpeed}");
            Debug.Log($"RunMotorWheel - _motor2DBack.motorSpeed = {_motor2DForward.motorSpeed}");
        }
    }
}