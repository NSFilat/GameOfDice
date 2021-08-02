using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private Renderer _diceRenderer;

    [SerializeField] private float jumpForce = 200f;

    private void Start()
    {
        _diceRigidbody = GetComponent<Rigidbody>();
        _diceRenderer = GetComponent<Renderer>();

        _diceRigidbody.maxAngularVelocity = Mathf.Infinity;
    }

    private void FixedUpdate()
    {
        _diceRigidbody.AddForce(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * jumpForce);

        //_diceRigidbody.AddForce(new Vector3(0f, 0f, 0f) * jumpForce);
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        //GUILayout.Label("Input.acceleration: " + Input.acceleration);
        GUI.Label(new Rect(0, 0, 300, 100), "Input.acceleration: " + Input.acceleration, myStyle);
       

    }

    private void Update()
    {
        _diceRenderer.material.color = (int)(1f / Time.deltaTime) <= 30 ? Color.red : Color.white;
    }
}
