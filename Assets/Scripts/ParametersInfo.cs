using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersInfo : MonoBehaviour
{
    [SerializeField] private Rigidbody _diceRigidbody;
    private float _maxSpeed = 0;

    private Dictionary<string, int> _parameters = new Dictionary<string, int>();
    private GUIStyle myStyle = new GUIStyle();

    static private int s_indent;

    public static int Indent { set { s_indent = value; } get { return s_indent; } }

    private void Start()
    {
        myStyle.fontSize = 40;
        s_indent = -40;
    }

    private void OnGUI()
    {
        PrintParameter("FPS", GetFPS());
        PrintParameter("Torque", Shaking.Torque);
        PrintParameter("MoveForce", Shaking.MoveForce);
        PrintParameter("MaxSpeed", GetMaxSpeed());
        PrintParameter("InputAccel", Input.acceleration);
    }

    private float GetMaxSpeed()
    {
        if (_diceRigidbody.velocity.magnitude > _maxSpeed)
        {
            _maxSpeed = _diceRigidbody.velocity.magnitude;
        }

        return _maxSpeed;
    }

    private void PrintParameter(string parameterName, object parameter)
    {
        if (WasParameter(parameterName))
        {
            GUI.Label(SetRectSize(_parameters[parameterName]), $"{parameterName}: " + parameter, myStyle);
        }
        else
        {
            s_indent += 40;
            _parameters.Add(parameterName, s_indent);
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