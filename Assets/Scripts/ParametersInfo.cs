using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersInfo: MonoBehaviour
{
    private float fps;
    static private int _currentIndent = -40;
    static private Rect _rectSize;

    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        PrintParameter("FPS", fps);
        PrintParameter("Torque", Shaking.Torque);
        PrintParameter("JumpForce", Shaking.MoveForce);

        //GUILayout.Label("Input.acceleration: " + Input.acceleration);
        //GUI.Label(new Rect(0, 0, 300, 100), "Default position: " + default_position, myStyle);
        //GUI.Label(new Rect(0, 40, 300, 100), "Input.acceleration: " + Input.acceleration, myStyle);
        //GUI.Label(new Rect(0, 80, 300, 100), "IsStart: " + IsStart, myStyle);
        //GUI.Label(new Rect(0, 120, 300, 100), "IsMoved: " + IsMoved, myStyle);
        //GUI.Label(new Rect(0, 160, 300, 100), "Speed: " + _diceRigidbody.velocity.magnitude, myStyle);
        //GUI.Label(new Rect(0, 200, 300, 100), "Velocity: " + velocity, myStyle);
        //GUI.Label(new Rect(0, 240, 300, 100), "AngularVelocity: " + _diceRigidbody.angularVelocity, myStyle);
    }

    private void PrintParameter(string parameterName, object parameter)
    {
        GUI.Label(_rectSize, $"{parameterName}: " + parameter, CheckGUIStyle());
        _rectSize = new Rect(0, _currentIndent + CheckGUIStyle().fontSize, 300, 100);
        _currentIndent += CheckGUIStyle().fontSize;

        DebugRectSize();
    }

    private GUIStyle CheckGUIStyle()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        return myStyle;
    }    

    private void DebugRectSize()
    {
        print(_rectSize);
    }

}
