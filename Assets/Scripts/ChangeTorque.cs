using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTorque : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    public void ChgeTorq()
    {
        ShakingWithAccelVelocity.Torque = float.Parse(inputField.text);
    }
}
