using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class MobAdsInterstitialVideo : MonoBehaviour
{
    private InterstitialAd InterstitialAd;

    private const string InterstitialUnitId = "ca-app-pub-3936460874675485/4257266677";

    private void OnEnable()
    {
        InterstitialAd = new InterstitialAd(InterstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        InterstitialAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {   
        if (InterstitialAd.IsLoaded())
        {
            InterstitialAd.Show();
            SceneManager.LoadScene(2);
        }
    }

}
