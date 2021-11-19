using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class MobAdsInterstitialVideo : MonoBehaviour
{
    private InterstitialAd InterstitialAd;

    private const string InterstitialUnitId = "ca-app-pub-3940256099942544/8691691433";

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
