using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenningSettingsFromGame : MonoBehaviour
{
    MobAdsInterstitialVideo mobAdsInterstitialVideo;
    public void OpenScene()
    {
        mobAdsInterstitialVideo.ShowAd();
        SceneManager.LoadScene(2);
    }
}
