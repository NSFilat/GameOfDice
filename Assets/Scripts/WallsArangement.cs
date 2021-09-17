using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsArangement : MonoBehaviour
{
    private const float _Size_x = 13.24f;
    private const float _Square = 49.30245f;

    [SerializeField] private readonly float _horizontalOffset = 0.5f;
    [SerializeField] private readonly float _verticalOffset = 2f;
    [SerializeField] private readonly float _floorOffset = 10f;

    [SerializeField] private Transform _upperWall;
    [SerializeField] private Transform _lowerWall;
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _floor;
    [SerializeField] private Transform _dice;

    private int _width = Screen.width;
    private int _height = Screen.height;

    private void Start()
    {
        _width /= FindGCD(_width, _height);
        _height /= FindGCD(_width, _height);

        ChangeWallsPosition(DefineSize(_width, _height));
        ChangeDiceScale(DefineSize(_width, _height));
    }


    private float DefineSize(int width, int height)
    {
        float coefficient = _Size_x / height;
        return  width * coefficient / 2;
    }

    private int FindGCD(int a, int b)
    {
        return b == 0 ? a : FindGCD(b, a % b);
    }

    private void ChangeWallsPosition(float position_z)
    {
        _leftWall.position = new Vector3(_leftWall.position.x, 0, -position_z - _horizontalOffset);
        _rightWall.position = new Vector3(_rightWall.position.x, 0, position_z + _horizontalOffset);

        _upperWall.localScale = new Vector3(_upperWall.localScale.x, _upperWall.localScale.y, position_z * 2 + _verticalOffset);
        _lowerWall.localScale = new Vector3(_lowerWall.localScale.x, _lowerWall.localScale.y, position_z * 2 + _verticalOffset);

        _floor.localScale = new Vector3((Mathf.Abs(_upperWall.position.x) * 2 + 1) / _floorOffset, 1, (Mathf.Abs(_rightWall.position.z) * 2 + 1) / _floorOffset);

    }

    private void ChangeDiceScale(float position_z)
    {
        float scale = 70 * position_z * _Size_x / _Square;
        _dice.localScale = new Vector3(scale, scale, scale);
    }
}