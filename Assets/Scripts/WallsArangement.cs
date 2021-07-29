using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsArangement : MonoBehaviour
{
    
    public Transform LeftWall;
    public Transform RightWall;
    public Transform UpperWall;
    public Transform LowerWall;
    
    
    const float size_x = 13.24f;


    // Start is called before the first frame update
    void Awake()
    {
        int width = Screen.width;
        int height = Screen.height;

        int NOD = FindNOD(width, height);

        print($"Screen width = {width} Screen height = {height} NOD = {NOD}");

        width /= NOD;
        height /= NOD;

        //float position_z = 0;

        DefineSize(width, height, out float position_z);

        LeftWall.position = new Vector3(LeftWall.position.x, 0, -position_z - 0.5f);
        RightWall.position = new Vector3(RightWall.position.x, 0, position_z + 0.5f);

        UpperWall.localScale = new Vector3(UpperWall.localScale.x, UpperWall.localScale.y, position_z * 2 + 2);
        LowerWall.localScale = new Vector3(LowerWall.localScale.x, LowerWall.localScale.y, position_z * 2 + 2);


    }

    private void DefineSize(float width, float height, out float position_z)
    {
        float koef = size_x / height;
        float result = width * koef;
        position_z = result / 2;

    }

    private int FindNOD(int a, int b)
    {
        if (a == 0)
        {
            return b;
        }
        else
        {
            while (b != 0)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
