using JoostenProductions;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    internal sealed class FloatInputJoystick : BaseInputView
    {
        [SerializeField] private Button _buttonGaz;
        [SerializeField] private Button _buttonJump;
        [SerializeField] private float _reverseSpeed = 1;
        private bool _isGaz;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
            _buttonJump.onClick.AddListener(Reverse);
        }

        private void Reverse()
        {
            _reverseSpeed *= -1;
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
            _buttonJump.onClick.RemoveListener(Reverse);
        }

        //Todo - этот метод по идее приватный, но  я думал прикрутить его к кнопкам. но даже так не получается сделать верно.
        private void Move()
        {
            if (_isGaz)
            {
                float moveStep = _speed * Time.deltaTime * _reverseSpeed;
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

        public void ActivatedGaz()
        {
            _isGaz = !_isGaz;
        }
    }
}