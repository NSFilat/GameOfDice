using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MobAdsBanner : MonoBehaviour
{
    private BannerView bannerView;
    private const string bannerUnitId = "ca-app-pub-3940256099942544/6300978111";

    private AdSize myAdSize = new AdSize(1920, 1080);

    private void OnEnable()
    {
        bannerView = new BannerView(bannerUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();
        bannerView.LoadAd(adRequest);
        StartCoroutine(ShowBanner());
    }

    IEnumerator ShowBanner()
    {
        yield return new WaitForSecondsRealtime(2f);
        bannerView.Show();
    }    
}
