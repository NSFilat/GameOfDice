using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationForShaking : MonoBehaviour
{
    public GameObject floor;
    private Vector3 default_position;
    public Vector3 Default_position { get { return default_position; } }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PreparationCoroutine());
    }

    bool flag = true;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == floor)
        {
            transform.position = new Vector3(0f, transform.position.y, 0f);
            transform.rotation = Quaternion.identity;
            Debug.Log("ColisionStay");
            flag = false;
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

        while (flag)
        {
            yield return null;
        }
        gameObject.AddComponent<Shaking>();
        Destroy(gameObject.GetComponent<PreparationForShaking>());        
    }
}
