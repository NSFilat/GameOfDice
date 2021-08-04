using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingForce : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    public void ChangeForce()
    {
        ShakingWithAccelVelocity.JumpForce = float.Parse(inputField.text);
    }
}
