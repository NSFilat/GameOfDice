using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private Renderer _diceRenderer;
    private Vector3 default_position;

    [SerializeField] private float jumpForce = 200f;

    private void Start()
    {
        _diceRigidbody = GetComponent<Rigidbody>();
        _diceRenderer = GetComponent<Renderer>();

        _diceRigidbody.maxAngularVelocity = Mathf.Infinity;
    }
    bool flag = true;
    private void FixedUpdate()
    {
        if (flag)
        {
            default_position = Input.acceleration;
            flag = false;
        }

        _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - default_position.z, 0f, Input.acceleration.x - default_position.x) * jumpForce);

        //_diceRigidbody.AddForce(new Vector3(0f, 0f, 0f) * jumpForce);
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        //GUILayout.Label("Input.acceleration: " + Input.acceleration);
        GUI.Label(new Rect(0, 0, 300, 100), "Default position: " + default_position, myStyle);
        GUI.Label(new Rect(0, 40, 300, 100), "Input.acceleration: " + Input.acceleration, myStyle);
       

    }

    private void Update()
    {
        _diceRenderer.material.color = (int)(1f / Time.deltaTime) <= 30 ? Color.red : Color.white;
    }
}
