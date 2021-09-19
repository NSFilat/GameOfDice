using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCompletition : MonoBehaviour
{
    private readonly float _reboundForce = 400f;

    private void OnCollisionStay(Collision collision)
    {
        if(IsWall(collision) && IsLowVelocity())
        {
            GetComponent<Rigidbody>().AddForce(_reboundForce, _reboundForce, _reboundForce);
            Destroy(gameObject.GetComponent<MovementCompletition>());
        }
    }

    private bool IsWall(Collision collision)
    {
        return collision.gameObject.CompareTag("Wall");
    }

    private bool IsLowVelocity()
    {
        return GetComponent<Rigidbody>().velocity.magnitude < 1;
    }
}
