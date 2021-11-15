using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingTorque : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Slider>().value = Shaking.Torque;
    }

    public void ChangeTorque(float value)
    {
        Shaking.Torque = value;
    }
}
