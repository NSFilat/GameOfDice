using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersInfo: MonoBehaviour
{
    static internal Dictionary<string, int> _parameters = new Dictionary<string, int>();
    private GUIStyle myStyle = new GUIStyle();
    
    static private int _indent = -40;

    internal static int Indent { set { _indent = value; } get { return _indent; } }

    private void Start()
    {
        myStyle.fontSize = 40;    
    }

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
            GUI.Label(SetRectSize(_parameters[parameterName]), $"{parameterName}: " + parameter, myStyle);
        }
        else 
        {
            _indent += 40;
            _parameters.Add(parameterName, _indent);
        }
    }

    private bool WasParameter(string parameterName)
    {
        return _parameters.ContainsKey(parameterName);
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
