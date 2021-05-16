using System;


namespace JevLogin
{
    internal interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action succesShow);
    }
}