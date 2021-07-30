using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTimeout : MonoBehaviour
{
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
