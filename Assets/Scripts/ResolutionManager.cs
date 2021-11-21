using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public const float Size_x = 13.24f;
    public const float Square = 49.30245f;

    private static int _width = Screen.width;
    private static int _height = Screen.height;


    private void Awake()
    {
        int GCD = FindGCD(_width, _height);

        _width /= GCD;
        _height /= GCD;
    }

    private int FindGCD(int a, int b)
    {
        return b == 0 ? a : FindGCD(b, a % b);
    }

    public static float DefineSize()
    {
        float coefficient = ResolutionManager.Size_x / _height;
        return _width * coefficient / 2;
    }
}