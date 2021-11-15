using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "4453209";
    private string _banner = "Banner_Android";
    private string _rewardedVideo = "Rewarded_Android";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);

        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement not ready!");
        }
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(_banner);
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new System.NotImplementedException();
    }
}
