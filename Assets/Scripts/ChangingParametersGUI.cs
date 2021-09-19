using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingParametersGUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.InputField inputField;

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
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Debbuger.SetStartParameters();
        Debbuger.SetStartGUIParameters();
    }
}
