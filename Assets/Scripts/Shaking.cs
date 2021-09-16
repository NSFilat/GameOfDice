using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private Vector3 default_position;

    [SerializeField] private static float _torque = 5000f;
    [SerializeField] private static float _moveForce = 20000f;
    [SerializeField] private readonly float _begin_speed = 15f;
    [SerializeField] private readonly float _end_speed = 1f;

    internal static float Torque { set { _torque = value; } get { return _torque; } }
    internal static float MoveForce { set { _moveForce = value; } get { return _moveForce; } }

    private void Start()
    {
        _diceRigidbody = GetComponent<Rigidbody>();
        _diceRigidbody.maxAngularVelocity = 50;
        StartCoroutine(PreparationCoroutine());    
    }

    IEnumerator PreparationCoroutine()
    {
        while (Input.acceleration == Vector3.zero)
        {
            yield return null;
        }

        default_position = Input.acceleration;
        StartCoroutine(ShakingCoroutine());
    }

    bool IsMoved = true;
    double velocity = 0;

    IEnumerator ShakingCoroutine()
    {
        IsMoved = false;

        float x_prev = default_position.x;
        float z_prev = default_position.z;

        float x_prev_for_velocity = default_position.x;
        float z_prev_for_velocity = default_position.z;

        while (!IsMoved)
        {
            velocity = ChangeVelocity(x_prev_for_velocity, z_prev_for_velocity);
            if (velocity > _begin_speed)
            {
                ChangeForce(ref x_prev, ref z_prev);
                IsMoved = !IsMoved;
            }

            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref z_prev_for_velocity);
            yield return null;
        }

        while (IsMoved)
        {
            velocity = ChangeVelocity(x_prev_for_velocity, z_prev_for_velocity);
            ChangeForce(ref x_prev, ref z_prev);

            if (velocity < _end_speed)
            {
                if(!gameObject.GetComponent<MovementCompletition>()) gameObject.AddComponent<MovementCompletition>();
                IsMoved = !IsMoved;
            }

            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref z_prev_for_velocity);
            yield return null;
        }

        //Debug.Log("---------------");
        StartCoroutine(PreparationCoroutine());
        //StartCoroutine(ShakingCoroutine());
    }

    private void ChangeVelocityCoodinates(ref float x_prev_for_velocity, ref float z_prev_for_velocity)
    {
        x_prev_for_velocity = Input.acceleration.x;
        z_prev_for_velocity = Input.acceleration.z;
    }

    static internal double ChangeVelocity(float x_prev_for_velocity, float z_prev_for_velocity)
    {
        return Mathf.Sqrt(Mathf.Pow((Input.acceleration.x - x_prev_for_velocity), 2) + Mathf.Pow((Input.acceleration.z - z_prev_for_velocity), 2)) / 0.02;
    }
    
    private void ChangeForce(ref float x_prev, ref float z_prev)
    {
        if (Mathf.Abs(Input.acceleration.x - x_prev) < 0.5f || Mathf.Abs(Input.acceleration.z - z_prev) < 0.5f)
        {
            _diceRigidbody.AddForce(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * (MoveForce - 100) * Time.deltaTime);
            _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque * Time.deltaTime);
            //_diceRigidbody.AddTorque(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * (jumpForce - 100));
            x_prev = Input.acceleration.x;
            z_prev = Input.acceleration.z;
        }
        else if (Mathf.Abs(Input.acceleration.x - x_prev) > 0.5f || Mathf.Abs(Input.acceleration.z - z_prev) > 0.5f)
        {
            _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - z_prev, 0f, Input.acceleration.x - x_prev) * MoveForce * Time.deltaTime);
            _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque * Time.deltaTime);
            //_diceRigidbody.AddTorque(new Vector3(Input.acceleration.z - z_prev, 0f, Input.acceleration.x - x_prev) * jumpForce);
        }
    }
}
