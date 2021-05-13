using UnityEngine;


namespace JevLogin
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class CarView : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        public WheelJoint2D WheelJoint2DBack;
        public WheelJoint2D WheelJoint2DForward;
        public SubscriptionProperty<bool> IsRotateWheels = new SubscriptionProperty<bool>();

        private JointMotor2D _motor2DBack;
        private JointMotor2D _motor2DForward;
        [SerializeField] private float _speedMotor;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            
            //TODO - назначаю мотор
            _motor2DBack = WheelJoint2DBack.motor;
            _motor2DForward = WheelJoint2DForward.motor;

            IsRotateWheels.SubscriptionOnChange(SwitchValueRotate);
        }

        private void OnDestroy()
        {
            IsRotateWheels.UnSubscriptionOnChange(SwitchValueRotate);
        }

        private void SwitchValueRotate(bool value)
        {
            //  Подписался на пропертю. и при изменении, запускаю разные методы.
            if (IsRotateWheels.Value)
            {
                RunMotorWheel();
            }
            else
            {
                StopMotorWheel();
            }
        }

        private void StopMotorWheel()
        {
            Debug.Log($"StopMotorWheel");

            _motor2DBack.motorSpeed = 0.0f;
            _motor2DForward.motorSpeed = 0.0f;
        }

        private void RunMotorWheel()
        {
            Debug.Log($"RunMotorWheel");

            _motor2DBack.motorSpeed = _speedMotor;
            _motor2DForward.motorSpeed = _speedMotor;
        }
    }
}