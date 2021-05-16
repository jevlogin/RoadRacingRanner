using UnityEngine.Advertisements;


namespace JevLogin
{
    internal interface IAdsBanner : IAds
    {
        void Show(BannerPosition bannerPosition);
    }
}