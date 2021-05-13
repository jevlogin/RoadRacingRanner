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
        
        private JointMotor2D _motorStop;
        private JointMotor2D _motorActivated;

        [SerializeField] private float _speedMotor;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();

            _motorStop = WheelJoint2DBack.motor;

            _motorActivated = _motorStop;
            _motorActivated.motorSpeed = _speedMotor;

            IsRotateWheels.SubscriptionOnChange(SwitchValueRotate);
        }

        private void OnDestroy()
        {
            IsRotateWheels.UnSubscriptionOnChange(SwitchValueRotate);
        }

        private void SwitchValueRotate(bool value)
        {
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
            WheelJoint2DBack.motor = _motorStop;
            WheelJoint2DForward.motor = _motorStop;
        }

        private void RunMotorWheel()
        {
            WheelJoint2DBack.motor = _motorActivated;
            WheelJoint2DForward.motor = _motorActivated;
        }
    }
}