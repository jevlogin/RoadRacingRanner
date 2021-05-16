using UnityEngine.Advertisements;


namespace JevLogin
{
    internal class AdsVideo : IAdsVideo
    {
        #region Fields

        private string _videoPlace;

        #endregion


        #region ClassLifeCycles

        public AdsVideo(string videoPlace)
        {
            _videoPlace = videoPlace;
        }

        #endregion


        #region IAdsVideo

        public bool IsReady()
        {
            return Advertisement.IsReady(_videoPlace);
        }

        public void Show()
        {
            Advertisement.Show(_videoPlace);
        }

        #endregion
    }
}