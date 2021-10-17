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
    }
}