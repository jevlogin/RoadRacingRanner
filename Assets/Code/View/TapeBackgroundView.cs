using UnityEngine;


namespace JevLogin
{
    internal sealed class TapeBackgroundView : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private Background[] _backgrounds;
        private IReadOnlySubscriptionProperty<float> _diff;

        #endregion


        #region Fields

        public void Init(IReadOnlySubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscriptionOnChange(Move);
        }

        private void Move(float value)
        {
            //Debug.Log($"_diff.value = {value}");

            if (_backgrounds != null)
            {
                foreach (Background background in _backgrounds)
                {
                    background.Move(-value);
                } 
            }
        } 

        #endregion
    }
}