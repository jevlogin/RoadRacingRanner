using UnityEngine.Advertisements;


namespace JevLogin
{
    internal class AdsBanner : IAdsBanner
    {
        #region Fields

        private string _bannerPlace;

        #endregion


        #region ClassLifeCycles

        public AdsBanner(string bannerPlace)
        {
            _bannerPlace = bannerPlace;
        }

        #endregion


        #region IAdsBanner

        public bool IsReady()
        {
            return Advertisement.IsReady(_bannerPlace);
        }

        public void Show(BannerPosition bannerPosition)
        {
            Advertisement.Banner.SetPosition(bannerPosition);
            Advertisement.Banner.Show(_bannerPlace);
        }

        #endregion
    }
}