using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingDice : MonoBehaviour
{
    [SerializeField] private Transform _dice;

    private void Start()
    {
        ChangeDiceScale(float position_z);
    }

    private void ChangeDiceScale(float position_z)
    {
        float scale = 70 * position_z * ResolutionManager.Size_x / ResolutionManager.Square;
        _dice.localScale = new Vector3(scale, scale, scale);
    }
}
