using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;


namespace JevLogin
{
    internal sealed class UnityAdsTools : MonoBehaviour
    {
        #region Fields

        private const string GOOGLE_PLAY_ID = "4116573";
        private const string APP_STORE_ID = "4116572";

        private const string _rewardPlace = "Rewarded_Android";
        private const string _videoPlace = "Interstitial_Android";
        private const string _bannerPlace = "Banner_Android";

        private string _gameId = string.Empty;

        [SerializeField] private Button _buttonBanner;
        [SerializeField] private Button _buttonVideo;
        [SerializeField] private Button _buttonRewardVideo;
        [SerializeField] private BannerPosition _bannerPosition;

        private IAdsBanner _adsBanner;
        private IAdsVideo _adsVideo;
        private IAdsRewardVideo _adsRewardVideo;
        private IUnityAdsListener _unityAdsListener;

        #endregion


        #region ClassLifeCycles

        private void Start()
        {
            _gameId = GOOGLE_PLAY_ID;
#if UNITY_ANDROID
            _gameId = GOOGLE_PLAY_ID;
#endif
#if UNITY_IOS
            _gameId = APP_STORE_ID; 
#endif

            _adsBanner = new AdsBanner(_bannerPlace);
            _adsVideo = new AdsVideo(_videoPlace);
            _adsRewardVideo = new AdsRewardVideo(_rewardPlace);
            _unityAdsListener = new UnityAdsListener(_rewardPlace);

            Advertisement.Initialize(_gameId, true);
        }


        private void OnEnable()
        {
            Advertisement.AddListener(_unityAdsListener);
            _buttonBanner.onClick.AddListener(ShowAdsBanner);
            _buttonVideo.onClick.AddListener(ShowAdsVideo);
            _buttonRewardVideo.onClick.AddListener(ShowAdsRewardVideo);
        }

        private void OnDisable()
        {
            Advertisement.RemoveListener(_unityAdsListener);
            _buttonBanner.onClick.RemoveAllListeners();
            _buttonVideo.onClick.RemoveAllListeners();
            _buttonRewardVideo.onClick.RemoveAllListeners();
        }

        private void ShowAdsRewardVideo()
        {
            if (_adsRewardVideo.IsReady())
            {
                _adsRewardVideo.Show();
            }
        }

        private void ShowAdsVideo()
        {
            if (_adsVideo.IsReady())
            {
                _adsVideo.Show();
            }
        }

        private void ShowAdsBanner()
        {
            StartCoroutine(ShowAdsBannerReady());
        }

        private IEnumerator ShowAdsBannerReady()
        {
            while (!_adsBanner.IsReady())
            {
                yield return new WaitForSeconds(1.0f);
            }
            _adsBanner.Show(_bannerPosition);
        }

        #endregion

    }
}