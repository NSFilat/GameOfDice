using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingWithAccelVelocity : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private Renderer _diceRenderer;
    private Vector3 default_position;

    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float torque = 50f;
    [SerializeField] private float begin_speed = 15f;
    [SerializeField] private float end_speed = 1f;

    public float Torque { set { torque = value; } get { return torque; } }

    private void Start()
    {
        _diceRigidbody = GetComponent<Rigidbody>();
        _diceRenderer = GetComponent<Renderer>();

        _diceRigidbody.maxAngularVelocity = Mathf.Infinity;
        StartCoroutine(PreparationCoroutine());
        
        
    }

    IEnumerator PreparationCoroutine()
    {
        while (Input.acceleration == Vector3.zero)
        {
            yield return null;
        }

        default_position = Input.acceleration;
        //Debug.Log($"Default position11111 = {default_position}");
        StartCoroutine(ShakingCoroutine());
    }

    bool IsStart = true;
    bool IsMoved = true;
    double velocity = 0;
    IEnumerator ShakingCoroutine()
    {
        //Debug.Log($"Default position = {default_position}");
        IsStart = true;
        IsMoved = true;

        //float speed = _diceRigidbody.velocity.magnitude;

        float x_prev = default_position.x;
        float z_prev = default_position.z;

        float x_prev_for_velocity = default_position.x;
        float z_prev_for_velocity = default_position.z;

        //float timeStart = 0f;

        while (IsStart)
        {
            velocity = Mathf.Sqrt(Mathf.Pow((Input.acceleration.x - x_prev_for_velocity), 2) + Mathf.Pow((Input.acceleration.z - z_prev_for_velocity), 2)) / 0.02;
            //Debug.Log(Mathf.Sqrt(Mathf.Pow((Input.acceleration.x - x_prev), 2) + Mathf.Pow((Input.acceleration.z - z_prev), 2)) / 0.02);
            if (velocity > 15)
            {
                if (Mathf.Abs(Input.acceleration.x - x_prev) < 0.5f || Mathf.Abs(Input.acceleration.z - z_prev) < 0.5f)
                {
                    _diceRigidbody.AddForce(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * (jumpForce - 100));
                    _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque);
                    //_diceRigidbody.AddTorque(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * (jumpForce - 100));
                    x_prev = Input.acceleration.x;
                    z_prev = Input.acceleration.z;
                }
                else if (Mathf.Abs(Input.acceleration.x - x_prev) > 0.5f || Mathf.Abs(Input.acceleration.z - z_prev) > 0.5f)
                {
                    _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - z_prev, 0f, Input.acceleration.x - x_prev) * jumpForce);
                    _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque);
                    //_diceRigidbody.AddTorque(new Vector3(Input.acceleration.z - z_prev, 0f, Input.acceleration.x - x_prev) * jumpForce);
                }

                IsStart = !IsStart;
            }

            x_prev_for_velocity = Input.acceleration.x;
            z_prev_for_velocity = Input.acceleration.z;
            yield return null;
        }

        while (IsMoved)
        {
            velocity = Mathf.Sqrt(Mathf.Pow((Input.acceleration.x - x_prev_for_velocity), 2) + Mathf.Pow((Input.acceleration.z - z_prev_for_velocity), 2)) / 0.02;
            if (Mathf.Abs(Input.acceleration.x - x_prev) < 0.5f || Mathf.Abs(Input.acceleration.z - z_prev) < 0.5f)
            {
                _diceRigidbody.AddForce(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * (jumpForce - 100));
                _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque);
                //_diceRigidbody.AddTorque(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * (jumpForce - 100));
                x_prev = Input.acceleration.x;
                z_prev = Input.acceleration.z;
            }
            else if (Mathf.Abs(Input.acceleration.x - x_prev) > 0.5f || Mathf.Abs(Input.acceleration.z - z_prev) > 0.5f)
            {
                _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - z_prev, 0f, Input.acceleration.x - x_prev) * jumpForce);
                _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque);
                //_diceRigidbody.AddTorque(new Vector3(Input.acceleration.z - z_prev, 0f, Input.acceleration.x - x_prev) * jumpForce);
            }

            if (velocity < 3)
            {
                IsMoved = !IsMoved;
            }

            x_prev_for_velocity = Input.acceleration.x;
            z_prev_for_velocity = Input.acceleration.z;

            yield return null;
        }

        //Debug.Log("---------------");
        StartCoroutine(PreparationCoroutine());
        //StartCoroutine(ShakingCoroutine());
    }


    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        //GUILayout.Label("Input.acceleration: " + Input.acceleration);
        GUI.Label(new Rect(0, 0, 300, 100), "Default position: " + default_position, myStyle);
        GUI.Label(new Rect(0, 40, 300, 100), "Input.acceleration: " + Input.acceleration, myStyle);
        GUI.Label(new Rect(0, 80, 300, 100), "IsStart: " + IsStart, myStyle);
        GUI.Label(new Rect(0, 120, 300, 100), "IsMoved: " + IsMoved, myStyle);
        GUI.Label(new Rect(0, 160, 300, 100), "Speed: " + _diceRigidbody.velocity.magnitude, myStyle);
        GUI.Label(new Rect(0, 200, 300, 100), "Velocity: " + velocity, myStyle);
        GUI.Label(new Rect(0, 240, 300, 100), "AngularVelocity: " + _diceRigidbody.angularVelocity, myStyle);
        GUI.Label(new Rect(0, 280, 300, 100), "Torque: " + Torque, myStyle);

    }
}
