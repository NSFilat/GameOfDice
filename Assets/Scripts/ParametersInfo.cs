using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersInfo: MonoBehaviour
{
    private float fps;

    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;

        PrintParameter("FPS", (int)fps, 0);
        PrintParameter("Torque", Shaking.Torque, 40);
        PrintParameter("JumpForce", Shaking.MoveForce, 80);
    }

    private void PrintParameter(string parameterName, object parameter, int indent)
    {
        GUI.Label(SetRectSize(indent), $"{parameterName}: " + parameter, CheckGUIStyle());
    }

    private GUIStyle CheckGUIStyle()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        return myStyle;
    }    

    private Rect SetRectSize(int indent)
    {
        return new Rect(0, indent, 300, 100);
    }    
}
