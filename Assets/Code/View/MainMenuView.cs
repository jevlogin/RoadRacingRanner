using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace JevLogin
{
    internal class MainMenuView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Button _buttonStart;

        #endregion


        #region Methods

        public void Init(UnityAction startGameAction)
        {
            _buttonStart.onClick.AddListener(startGameAction);
        }

        #endregion


        #region UnityMethods

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }

        #endregion
    }
}