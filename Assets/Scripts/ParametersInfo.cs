using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersInfo: MonoBehaviour
{
    Dictionary<string, int> _parameters = new Dictionary<string, int>();
    static int indent = -40;

    private void OnGUI()
    {
        PrintParameter("FPS", GetFPS());
        PrintParameter("Torque", Shaking.Torque);
        PrintParameter("JumpForce", Shaking.MoveForce);
    }

    private void PrintParameter(string parameterName, object parameter)
    {
        if ((WasParameter(parameterName)))
        {
            GUI.Label(SetRectSize(_parameters[parameterName]), $"{parameterName}: " + parameter, CheckGUIStyle());
        }
        else 
        {
            indent += 40;
            _parameters.Add(parameterName, indent);
        }
    }

    private bool WasParameter(string parameterName)
    {
        return _parameters.ContainsKey(parameterName);
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

    private int GetFPS()
    {
        return (int)(1.0f / Time.deltaTime);
    }
}
