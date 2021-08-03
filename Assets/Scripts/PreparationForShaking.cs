using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationForShaking : MonoBehaviour
{
    public GameObject floor;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == floor)
        {
            transform.position = new Vector3(0f, transform.position.y, 0f);
            transform.rotation = Quaternion.identity;
            //Debug.Log("ColisionStay");
            gameObject.AddComponent<Shaking>();
            Destroy(gameObject.GetComponent<PreparationForShaking>());
        }
    }
}
