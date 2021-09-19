using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private Vector3 _defaultPosition;

    private bool IsMoved = true;

    [SerializeField] private static float s_torque = 5000f;
    [SerializeField] private static float s_moveForce = 20000f;
    [SerializeField] private readonly float _begin_speed = 15f;
    [SerializeField] private readonly float _end_speed = 1f;

    public static float Torque { set { s_torque = value; } get { return s_torque; } }
    public static float MoveForce { set { s_moveForce = value; } get { return s_moveForce; } }

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

        _defaultPosition = Input.acceleration;
        StartCoroutine(ShakingCoroutine());
    }

    IEnumerator ShakingCoroutine()
    {
        IsMoved = false;

        float x_prev = _defaultPosition.x;
        float z_prev = _defaultPosition.z;

        float x_prev_for_velocity = _defaultPosition.x;
        float z_prev_for_velocity = _defaultPosition.z;

        while (!IsMoved)
        {
            if (GetVelocity(x_prev_for_velocity, z_prev_for_velocity) > _begin_speed)
            {
                ChangeForce(ref x_prev, ref z_prev);
                IsMoved = !IsMoved;
            }

            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref z_prev_for_velocity);
            yield return null;
        } 

        while (IsMoved)
        {
            ChangeForce(ref x_prev, ref z_prev);

            if (GetVelocity(x_prev_for_velocity, z_prev_for_velocity) < _end_speed)
            {
                if (!gameObject.GetComponent<MovementCompletition>())
                {
                    gameObject.AddComponent<MovementCompletition>();
                }
                IsMoved = !IsMoved;
            }

            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref z_prev_for_velocity);
            yield return null;
        }
        StartCoroutine(PreparationCoroutine());
    }

    static private double GetVelocity(float x_prev_for_velocity, float z_prev_for_velocity)
    {
        return Mathf.Sqrt(Mathf.Pow((Input.acceleration.x - x_prev_for_velocity), 2) + Mathf.Pow((Input.acceleration.z - z_prev_for_velocity), 2)) / 0.02;
    }

    private void ChangeVelocityCoodinates(ref float x_prev_for_velocity, ref float z_prev_for_velocity)
    {
        x_prev_for_velocity = Input.acceleration.x;
        z_prev_for_velocity = Input.acceleration.z;
    }
    
    private void ChangeForce(ref float x_prev, ref float z_prev)
    {
        if (GetOffsetX(x_prev) < 0.5f || GetOffsetZ(z_prev) < 0.5f)
        {
            _diceRigidbody.AddForce(new Vector3(Input.acceleration.z, 0f, Input.acceleration.x) * (MoveForce - 100) * Time.deltaTime);
            _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque * Time.deltaTime);

            x_prev = Input.acceleration.x;
            z_prev = Input.acceleration.z;
        }
        else if (GetOffsetX(x_prev) > 0.5f || GetOffsetZ(z_prev) > 0.5f)
        {
            _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - z_prev, 0f, Input.acceleration.x - x_prev) * MoveForce * Time.deltaTime);
            _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque * Time.deltaTime);
        }
    }

    private float GetOffsetX(float x_prev)
    {
        return Mathf.Abs(Input.acceleration.x - x_prev);
    }

    private float GetOffsetZ(float z_prev)
    {
        return Mathf.Abs(Input.acceleration.z - z_prev);
    }
}
