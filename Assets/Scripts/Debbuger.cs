using System.Collections;
using System.Collections.Generic;

public class Debbuger
{
    static public void SetStartParameters()
    {
        Shaking.Torque = 5000f;
        Shaking.MoveForce = 20000f;
    }

    static public void SetStartGUIParameters()
    {
        ParametersInfo.Indent = -40;
    }
}
