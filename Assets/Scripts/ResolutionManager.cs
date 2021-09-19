using System.Collections;
using System.Collections.Generic;

public class ResolutionManager
{
    public const float Size_x = 13.24f;
    public const float Square = 49.30245f;

    private static int s_width = UnityEngine.Screen.width;
    private static int s_height = UnityEngine.Screen.height;

    public static float DefineSize()
    {
        s_width /= FindGCD(s_width, s_height);
        s_height /= FindGCD(s_width, s_height);

        float coefficient = Size_x / s_height;
        return s_width * coefficient / 2;
    }

    private static int FindGCD(int a, int b)
    {
        return b == 0 ? a : FindGCD(b, a % b);
    }
}
