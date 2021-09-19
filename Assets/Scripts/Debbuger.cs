using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Debbuger : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    public void ChangeMoveForce()
    {
        Shaking.MoveForce = float.Parse(inputField.text);
    }
    public void ChangeTorque()
    {
        Shaking.Torque = float.Parse(inputField.text);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        SetStartParameters();
        SetStartGUIParameters();
    }

    private void SetStartParameters()
    {
        Shaking.Torque = 5000f;
        Shaking.MoveForce = 20000f;
    }

    private void SetStartGUIParameters()
    {
        ParametersInfo.Indent = -40;
    }
}
