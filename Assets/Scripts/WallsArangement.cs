using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsArangement : MonoBehaviour
{
    private const float Size_x = 13.24f;
    private const float Square = 921600;

    [SerializeField] private readonly float horizontalOffset = 0.5f;
    [SerializeField] private readonly float verticalOffset = 2f;
    [SerializeField] private readonly float floorOffset = 10f;

    [SerializeField] private Transform _upperWall;
    [SerializeField] private Transform _lowerWall;
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _floor;
    [SerializeField] private Transform _dice;


    void Start()
    {
        int width = Screen.width;
        int height = Screen.height;

        Debug.Log($"{width} + {height}");

        int GCD = FindGCD(width, height);

        width /= GCD;
        height /= GCD;

        DefineSize(width, height, out float position_z);

        _leftWall.position = new Vector3(_leftWall.position.x, 0, -position_z - horizontalOffset);
        _rightWall.position = new Vector3(_rightWall.position.x, 0, position_z + horizontalOffset);

        _upperWall.localScale = new Vector3(_upperWall.localScale.x, _upperWall.localScale.y, position_z * 2 + verticalOffset);
        _lowerWall.localScale = new Vector3(_lowerWall.localScale.x, _lowerWall.localScale.y, position_z * 2 + verticalOffset);

        _floor.localScale = new Vector3((Mathf.Abs(_upperWall.position.x) * 2 + 1) / floorOffset, 1, (Mathf.Abs(_rightWall.position.z) * 2 + 1) / floorOffset);
        
        float scale = 70 * Screen.width * Screen.height / Square;
        _dice.localScale = new Vector3(scale, scale, scale);

        Debug.Log(_dice.localScale);
    }

    private void DefineSize(int width, int height, out float position_z)
    {
        float coefficient = Size_x / height;
        position_z = width * coefficient / 2;
    }

    private int FindGCD(int a, int b)
    {
        return b == 0 ? a : FindGCD(b, a % b);
    }
}