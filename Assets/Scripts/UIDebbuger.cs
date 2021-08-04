using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDebbuger : MonoBehaviour
{
    private float fps;
        void OnGUI()
        {
        fps = 1.0f / Time.deltaTime;
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        //GUILayout.Label("Input.acceleration: " + Input.acceleration);
        //GUI.Label(new Rect(0, 0, 300, 100), "Default position: " + default_position, myStyle);
        //GUI.Label(new Rect(0, 40, 300, 100), "Input.acceleration: " + Input.acceleration, myStyle);
        //GUI.Label(new Rect(0, 80, 300, 100), "IsStart: " + IsStart, myStyle);
        //GUI.Label(new Rect(0, 120, 300, 100), "IsMoved: " + IsMoved, myStyle);
        //GUI.Label(new Rect(0, 160, 300, 100), "Speed: " + _diceRigidbody.velocity.magnitude, myStyle);
        //GUI.Label(new Rect(0, 200, 300, 100), "Velocity: " + velocity, myStyle);
        //GUI.Label(new Rect(0, 240, 300, 100), "AngularVelocity: " + _diceRigidbody.angularVelocity, myStyle);
        GUI.Label(new Rect(0, 280, 300, 100), "Torque: " + gameObject.GetComponent<ShakingWithAccelVelocity>().Torque, myStyle);

        }
}
