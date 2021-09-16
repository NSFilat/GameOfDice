using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCompletition : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall") && GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            GetComponent<Rigidbody>().AddForce(400, 400, 400);
            //Shaking.Torque = -1;
            Destroy(gameObject.GetComponent<MovementCompletition>());
        }
    }
}
