using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InertiaRotation : MonoBehaviour
{
    //public Quaternion InertiaRot = new Quaternion(10, 10, 10, 1);
    public Vector3 tensor;
    // Start is called before the first frame update
    void Start()
    {
        //print(Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().inertiaTensorRotation = InertiaRot;
        GetComponent<Rigidbody>().inertiaTensor = tensor;
    }
}
