using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationForShaking : MonoBehaviour
{
    public GameObject floor;
    public Vector3 default_position;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PreparationCoroutine());
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == floor)
        {
            transform.position = new Vector3(0f, transform.position.y, 0f);
            transform.rotation = Quaternion.identity;
            
            gameObject.GetComponent<PreparationForShaking>().enabled = false;
        }
    }


    IEnumerator PreparationCoroutine()
    {

        while (Input.acceleration == Vector3.zero)
        {
            yield return null;
        }

        default_position = Input.acceleration;
        Debug.Log(default_position);
        
    }
    

}
