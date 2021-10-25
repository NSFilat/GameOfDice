using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsArangement : MonoBehaviour
{
    [SerializeField] private readonly float _horizontalOffset = 2f;
    [SerializeField] private readonly float _verticalOffset = 8f;

    [SerializeField] private Transform _upperWall;
    [SerializeField] private Transform _lowerWall;
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _leftWall;

    [SerializeField] private Transform _upperLeftCorner;
    [SerializeField] private Transform _upperRightCorner;
    [SerializeField] private Transform _lowerRightCorner;
    [SerializeField] private Transform _lowerLeftCorner;

    private void Start()
    {
        ChangeWallsPosition(ResolutionManager.DefineSize());
    }

    private void ChangeWallsPosition(float position_z)
    {
        _leftWall.position  = new Vector3(_leftWall.position.x, 0, -position_z - _horizontalOffset);
        _rightWall.position = new Vector3(_rightWall.position.x, 0, position_z + _horizontalOffset);

        _upperWall.localScale = new Vector3(_upperWall.localScale.x, _upperWall.localScale.y, position_z * 2 + _verticalOffset);
        _lowerWall.localScale = new Vector3(_lowerWall.localScale.x, _lowerWall.localScale.y, position_z * 2 + _verticalOffset);

        _upperLeftCorner.position = new Vector3(_upperWall.position.x + _horizontalOffset, 0, _leftWall.position.z + _horizontalOffset);
        _upperRightCorner.position = new Vector3(_upperWall.position.x + _horizontalOffset, 0, _rightWall.position.z - _horizontalOffset);
        _lowerLeftCorner.position = new Vector3(_lowerWall.position.x - _horizontalOffset, 0, _leftWall.position.z + _horizontalOffset);
        _lowerRightCorner.position = new Vector3(_lowerWall.position.x - _horizontalOffset, 0, _rightWall.position.z - _horizontalOffset);
    }
}