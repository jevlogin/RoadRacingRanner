using UnityEngine.Advertisements;


namespace JevLogin
{
    internal class AdsRewardVideo : IAdsRewardVideo
    {
        #region Fields

        private string _rewardPlace;

        #endregion


        #region ClassLifeCycles

        public AdsRewardVideo(string rewardPlace)
        {
            _rewardPlace = rewardPlace;
        }

        #endregion


        #region IAdsRewardVideo

        public bool IsReady()
        {
            return Advertisement.IsReady(_rewardPlace);
        }

        public void Show()
        {
            ShowOptions options = new ShowOptions();
            Advertisement.Show(_rewardPlace, options);
        }

        #endregion
    }
}