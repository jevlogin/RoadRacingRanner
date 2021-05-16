using UnityEngine;
using UnityEngine.Advertisements;

namespace JevLogin
{
    internal class UnityAdsListener : IUnityAdsListener
    {
        #region Fields

        private string _rewardPlace;
        private bool _adsAreReady;

        #endregion

        #region Properties

        public bool AdsAreReady => _adsAreReady;

        #endregion


        #region ClassLifeCycles

        public UnityAdsListener(string rewardPlace)
        {
            _rewardPlace = rewardPlace;
        }

        #endregion


        #region IUnityAdsListener

        public void OnUnityAdsDidError(string message)
        {
            Debug.LogWarning($"Error: {message}");
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    Debug.Log("Failed");
                    break;

                case ShowResult.Skipped:
                    Debug.Log("Skipped");
                    break;

                case ShowResult.Finished:
                    Debug.Log("Finished");
                    break;

                default:
                    throw new System.ArgumentException(nameof(showResult));
            }
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            // Optional actions to take when the end-users triggers an ad.
        }

        public void OnUnityAdsReady(string placementId)
        {
            if (placementId != _rewardPlace)
            {
                return;
            }
            _adsAreReady = true;
        }

        #endregion
    }
}