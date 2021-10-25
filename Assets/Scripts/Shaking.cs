using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private static Vector3 _defaultPosition;

    public static bool IsMoved = true;
    public static bool IsTorque = true;

    public static double AccelVelocity = 0;

    public static int Times = 0;

    [SerializeField] private static float s_torque = 5000f;
    [SerializeField] private static float s_moveForce = 25000f;
    [SerializeField] private readonly float _maxSpeed = 50f;
    [SerializeField] private readonly float _begin_speed = 15f;
    [SerializeField] private readonly float _end_speed = 1f;

    public static float Torque { set { s_torque = value; } get { return s_torque; } }
    public static float MoveForce { set { s_moveForce = value; } get { return s_moveForce; } }

    public static Vector3 DefualtPosition { set { _defaultPosition = value; } get { return _defaultPosition; } }

    private void Start()
    {
        _diceRigidbody = GetComponent<Rigidbody>();
        _diceRigidbody.maxAngularVelocity = 30;

        StartCoroutine(PreparationCoroutine());
    }

    IEnumerator PreparationCoroutine()
    {
        while (Input.acceleration == Vector3.zero)
        {
            yield return null;
        }

        //_diceRigidbody.maxAngularVelocity = 50;
        _defaultPosition = Input.acceleration;
        Times++;
        StartCoroutine(ShakingCoroutine());
    }

    IEnumerator ShakingCoroutine()
    {
        IsMoved = false;
        IsTorque = true;
        double prev_accel_speed = 0;
        double cur_accel_speed = 0;
        float x_prev_for_velocity = _defaultPosition.x;
        float z_prev_for_velocity = _defaultPosition.z;
        
        while (!IsMoved)
        {
            cur_accel_speed = GetVelocity(x_prev_for_velocity, z_prev_for_velocity);

            if(Mathf.Abs((float)(cur_accel_speed - prev_accel_speed)) > _begin_speed)
            {
                ChangeForce();
                IsMoved = !IsMoved;
            }

            prev_accel_speed = cur_accel_speed;
            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref z_prev_for_velocity);
            yield return null;
        }

        while (IsMoved)
        {
            ChangeForce();
            cur_accel_speed = GetVelocity(x_prev_for_velocity, z_prev_for_velocity);

            //Debug.Log($"Cur_accel speed = {cur_accel_speed}");
            //Debug.Log($"Prev_accel speed = {prev_accel_speed}");

            if (Mathf.Abs((float)(cur_accel_speed - prev_accel_speed)) < _end_speed && cur_accel_speed < 1 && cur_accel_speed != 0)
            {
                if (!gameObject.GetComponent<MovementCompletition>())
                {
                    gameObject.AddComponent<MovementCompletition>();
                }
                //_diceRigidbody.maxAngularVelocity = 10;
                IsTorque = !IsTorque;
                IsMoved = !IsMoved;
            }

            prev_accel_speed = cur_accel_speed;
            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref z_prev_for_velocity); 
            yield return null;
        }

        while(!IsMoved)
        {
            if (_diceRigidbody.velocity.magnitude < 1)
                IsMoved = !IsMoved;
            //Debug.Log("End moving !!");
            yield return null;
        }

        StartCoroutine(PreparationCoroutine());
    }

    static private double GetVelocity(float x_prev_for_velocity, float z_prev_for_velocity)
    {
        return AccelVelocity = Mathf.Sqrt(Mathf.Pow(Input.acceleration.x - x_prev_for_velocity, 2) + Mathf.Pow(Input.acceleration.z - z_prev_for_velocity, 2)) / 0.02;
    }

    private void ChangeVelocityCoodinates(ref float x_prev_for_velocity, ref float z_prev_for_velocity)
    {
        x_prev_for_velocity = Input.acceleration.x;
        z_prev_for_velocity = Input.acceleration.z;
    }

    private void ChangeForce()
    {
        _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - _defaultPosition.z, 0f, Input.acceleration.x - _defaultPosition.x) * MoveForce * Time.deltaTime);
        if(IsTorque)_diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque * Time.deltaTime);
        _diceRigidbody.velocity = Vector3.ClampMagnitude(_diceRigidbody.velocity, _maxSpeed);
    }
}