using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public const float Size_x = 13.24f;
    public const float Square = 49.30245f;

    private static int s_width = Screen.width;
    private static int s_height = Screen.height;

    public static int Width { set { s_width = value; } get { return s_width; } }
    public static int Height { set { s_height = value; } get { return s_height; } }

    private void Start()
    {
        s_width /= FindGCD(s_width, s_height);
        s_height /= FindGCD(s_width, s_height);
    }

    private int FindGCD(int a, int b)
    {
        return b == 0 ? a : FindGCD(b, a % b);
    }

    public static float DefineSize(int width, int height)
    {
        float coefficient = Size_x / height;
        return width * coefficient / 2;
    }
}
