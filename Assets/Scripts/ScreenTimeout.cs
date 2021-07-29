using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTimeout : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
