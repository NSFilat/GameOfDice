using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingMoveForce : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Slider>().value = Shaking.MoveForce;
    }

    public void MoveForce(float value)
    {
        Shaking.MoveForce = value;
    }
}
