using UnityEngine;


namespace JevLogin
{
    internal sealed class Background : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private float _relativeSpeedRate;

        private float _twoBorder;

        #endregion

        private void Awake()
        {
            _twoBorder = _rightBorder + _rightBorder;
        }

        #region Methods

        public void Move(float value)
        {
            transform.position += Vector3.right * value * _relativeSpeedRate;
            Vector3 position = transform.position;

            if (position.x <= -_twoBorder)
            {
                var x1 = _twoBorder - (_leftBorder - position.x);
                transform.position = new Vector3(x1, position.y, position.z);
            }
            else if (position.x >= _twoBorder)
            {
                var x2 = -_twoBorder - (_rightBorder - position.x);
                transform.position = new Vector3(x2, position.y, position.z);
            }
        }

        #endregion
    }
}