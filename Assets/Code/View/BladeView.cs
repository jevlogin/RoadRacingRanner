using JoostenProductions;
using UnityEngine;


namespace JevLogin
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    internal sealed class BladeView : BaseInputView
    {
        #region Fields

        [SerializeField] private bool _isCutting;
        [SerializeField] private GameObject _trailPrefab;
        [SerializeField] private float _minCuttingVelocity = 0.001f;

        private Rigidbody2D _rigidbody2D;
        private Camera _camera;
        private GameObject _currrentBladeTrail;
        private Collider2D _collider2D;
        private Vector2 _previousPosition = Vector2.zero;
        private Vector2 _newPosition = Vector2.zero;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _camera = Camera.main;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            _collider2D = GetComponent<Collider2D>();
            _collider2D.isTrigger = true;
            
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(UpdateButtonDown);
        }

        #endregion


        #region ClassLifeCycles

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(UpdateButtonDown);
        }

        #endregion


        #region Methods

        private void UpdateButtonDown()
        {
            if (Input.GetButtonDown(AxisManager.FIRE1))
            {
                StartCutting();
            }
            else if (Input.GetButtonUp(AxisManager.FIRE1))
            {
                StopCutting();
            }

            if (_isCutting)
            {
                UpdateCut();
            }
        }

        private void UpdateCut()
        {
            _newPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _rigidbody2D.position = _newPosition;

            var velocity = (_newPosition - _previousPosition).magnitude * Time.deltaTime;
            if (velocity > _minCuttingVelocity)
            {
                _collider2D.enabled = true;
            }
            else
            {
                _collider2D.enabled = false;
            }
            _previousPosition = _newPosition;
        }

        private void StopCutting()
        {
            _isCutting = false;
            _currrentBladeTrail.transform.SetParent(null);
            Destroy(_currrentBladeTrail, 1.0f);
            _collider2D.enabled = false;
        }

        private void StartCutting()
        {
            _isCutting = true;
            _currrentBladeTrail = Instantiate(_trailPrefab, transform);
            _previousPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _collider2D.enabled = false;
        }

        #endregion
    }
}