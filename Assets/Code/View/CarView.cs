using UnityEngine;


namespace JevLogin
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class CarView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _startForce;

        private WheelJoint2D[] _wheelJoint2Ds;
        private Rigidbody2D[] _rigidbody2DChilds;
        private Rigidbody2D _rigidbody2D;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _wheelJoint2Ds = GetComponentsInChildren<WheelJoint2D>();
            _rigidbody2DChilds = GetComponentsInChildren<Rigidbody2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rigidbody2D.AddForce(transform.up * _startForce, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BladeView>(out var bladeView))
            {
                foreach (var wheelJoint in _wheelJoint2Ds)
                {
                    wheelJoint.enabled = false;
                }
                for (int i = 1; i < _rigidbody2DChilds.Length; i++)
                {
                    Rigidbody2D rigidbody = _rigidbody2DChilds[i];
                    rigidbody.AddForce(transform.up * _startForce, ForceMode2D.Impulse);
                }
                Destroy(gameObject, 3.0f);
            }
        }

        #endregion
    }
}