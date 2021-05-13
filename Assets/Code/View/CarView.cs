using UnityEngine;


namespace JevLogin
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class CarView : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        public WheelJoint2D WheelJoint2DBack;
        public WheelJoint2D WheelJoint2DForward;


        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}