using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MobAdsBanner : MonoBehaviour
{
    private BannerView bannerView;
    private const string bannerUnitId = "ca-app-pub-3936460874675485/6026160832";

    private void OnEnable()
    {
        AdSize adSize = new AdSize(320, 50);
        bannerView = new BannerView(bannerUnitId, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();
        bannerView.LoadAd(adRequest);
       
        //bannerView = new BannerView(bannerUnitId, adSize, AdPosition.Bottom);
    }   
}
