using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    [SerializeField] private float jumpForce = 1000f;

    private float x;
    private float y;
    private float z;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            x = Random.Range(-1f, 1f);
            y = Random.Range(0.5f, 0.8f);
            z = Random.Range(-1f, 1f);

            playerRigidbody.AddForce(new Vector3(x, 0, z) * jumpForce);
        }
    }
}
