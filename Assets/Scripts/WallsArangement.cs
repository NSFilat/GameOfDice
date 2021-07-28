using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsArangement : MonoBehaviour
{
    public Transform LeftWall;
    public Transform RightWall;
    public Transform UpperWall;
    public Transform LowerWall;
    // Start is called before the first frame update
    void Awake()
    {
        //gameObject.transform.position = new Vector3(Screen.width, Screen)

        print($"Screen width = {Screen.width}  Screen heigth = {Screen.height}");
        //Camera.main.he = 0.5625f;
        print(Camera.main.aspect);

        /*
        float left_x = -0.3f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);
        float left_z = -4.2f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);

        LeftWall.position = new Vector3(left_x, 0, left_z);

        print(LeftWall.position);

        float right_x = -0.3f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);
        float right_z = 4.2f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);

        RightWall.position = new Vector3(right_x, 0, right_z);

        float upper_x = -7.13f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);
        float upper_z = 0.08f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);

        UpperWall.position = new Vector3(upper_x, 0, upper_z);

        float lower_x = 7.13f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);
        float lower_z = -0.08f * ((float)(Screen.height) / Screen.width) / (16.0f / 9.0f);

        LowerWall.position = new Vector3(lower_x, 0, lower_z);
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
