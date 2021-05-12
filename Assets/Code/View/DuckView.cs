using UnityEngine;


namespace JevLogin
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class DuckView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _startForce;
        [SerializeField] private float _killForce;
        [SerializeField] private AnimationClip _animationIdle;
        [SerializeField] private AnimationClip _animationDie;

        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;
        private bool _isDied = false;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
        }

        private void Start()
        {
            _rigidbody2D.AddForce(transform.up * _startForce, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BladeView>(out var blade))
            {
                _rigidbody2D.AddForce(transform.up * _killForce, ForceMode2D.Impulse);
                _collider2D.enabled = false;
                _isDied = true;
                _animator.SetBool("IsDied", _isDied);

                Destroy(gameObject, 3.0f);
            }
        }

        #endregion
    }
}