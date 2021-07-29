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
        //y = gameObject.GetComponent<BoxCollider>().size.y;
        //y = gameObject.GetComponent<MeshCollider>().bounds.size.y;
        //transform.position = new Vector3(0f, y / 2, 0f);
        //print(y / 2);
       
    }
    private void FixedUpdate()
    {
        _playerRigidbody.AddForce(new Vector3 (Input.acceleration.z, 0f, Input.acceleration.x) * jumpForce);
        //_playerRigidbody.AddForce(new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal")) * jumpForce);
    }
}
