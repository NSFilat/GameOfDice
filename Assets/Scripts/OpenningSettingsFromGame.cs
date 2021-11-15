using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenningSettingsFromGame : MonoBehaviour
{
    public void OpenScene()
    {
        AdsCore.ShowAdsVideo("Interstitial_Android");
        SceneManager.LoadScene(2);
    }
}
