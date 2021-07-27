using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody _playerRigidbody;

    [SerializeField] private float jumpForce = 200f;

    private float x;
    private float y;
    private float z;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerRigidbody.maxAngularVelocity = Mathf.Infinity;
    }

    private void Update()
    {
        _playerRigidbody.AddForce(new Vector3 (Input.acceleration.x, 0f, -Input.acceleration.z) * jumpForce);
    }
}
