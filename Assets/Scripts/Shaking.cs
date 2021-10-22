using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private static Vector3 _defaultPosition;

    public static bool IsMoved = true;
    public static bool WasStart = false;

    public static double AccelVelocity = 0;

    public static int Times = 0;

    [SerializeField] private static float s_torque = 6000f;
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
        Times++;
        StartCoroutine(ShakingCoroutine());
    }

    IEnumerator ShakingCoroutine()
    {
        IsMoved = false;

        float x_prev_for_velocity = _defaultPosition.x;
        float y_prev_for_velocity = _defaultPosition.y;
        float z_prev_for_velocity = _defaultPosition.z;
        
        while (!IsMoved)
        {
            if (GetVelocity(x_prev_for_velocity, y_prev_for_velocity, z_prev_for_velocity) > _begin_speed)
            {
                ChangeForce();
                IsMoved = !IsMoved;
            }

            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref y_prev_for_velocity, ref z_prev_for_velocity);
            yield return null;
        }

        while (IsMoved)
        {
            ChangeForce();

            if (GetVelocity(x_prev_for_velocity, y_prev_for_velocity, z_prev_for_velocity) < _end_speed && _diceRigidbody.velocity.magnitude < 15)
            {
                _defaultPosition = Input.acceleration;
                if (_diceRigidbody.velocity.magnitude < _end_speed)
                {
                    if (!gameObject.GetComponent<MovementCompletition>())
                    {
                        gameObject.AddComponent<MovementCompletition>();
                    }
                    IsMoved = !IsMoved;
                }
            }

            ChangeVelocityCoodinates(ref x_prev_for_velocity, ref y_prev_for_velocity, ref z_prev_for_velocity); 
            yield return null;
        }

        StartCoroutine(PreparationCoroutine());
    }

    static private double GetVelocity(float x_prev_for_velocity, float y_prev_for_velocity, float z_prev_for_velocity)
    {
        return AccelVelocity = Mathf.Sqrt(Mathf.Pow(Input.acceleration.x - x_prev_for_velocity, 2) + Mathf.Pow(Input.acceleration.y - y_prev_for_velocity, 2) +
            Mathf.Pow(Input.acceleration.z - z_prev_for_velocity, 2)) / 0.02;
    }

    private void ChangeVelocityCoodinates(ref float x_prev_for_velocity, ref float y_prev_for_velocity, ref float z_prev_for_velocity)
    {
        x_prev_for_velocity = Input.acceleration.x;
        y_prev_for_velocity = Input.acceleration.y;
        z_prev_for_velocity = Input.acceleration.z;
    }

    private void ChangeForce()
    {
        _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - _defaultPosition.z, 0f, Input.acceleration.x - _defaultPosition.x) * MoveForce * Time.deltaTime);
        _diceRigidbody.AddTorque(new Vector3(0, 1, 0) * Torque * Time.deltaTime);
        _diceRigidbody.velocity = Vector3.ClampMagnitude(_diceRigidbody.velocity, _maxSpeed);
    }
}