using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingSound : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Toggle>().isOn = ParametersInfo.IsOn;
    }

    public void SwitchSound(bool isOn)
    {
        ParametersInfo.IsOn = isOn;
        AudioListener.volume = isOn ? 1 : 0;
    }
}
