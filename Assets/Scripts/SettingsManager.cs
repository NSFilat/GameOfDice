using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private void Awake()
    {
        SetFrameRate();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void SetFrameRate()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    
}
