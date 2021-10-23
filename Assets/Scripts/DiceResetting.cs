using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceResetting : MonoBehaviour
{
    [SerializeField] private Transform _upperWall;
    [SerializeField] private Transform _lowerWall;
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _floor;

    private Transform _diceTransform;

    private void Start()
    {
        _diceTransform = GetComponent<Transform>();
    }

    private void Update()
    {
       // Debug.Log($"Accel_velocity = {Shaking.AccelVelocity}");
        if (CheckX() || CheckY() || CheckZ())
        {
            _diceTransform.position = new Vector3(0, SettingDicePosition.DiceStartPosition, 0);
        }
    }

    private bool CheckX()
    {
        
        return (_diceTransform.position.x < _upperWall.transform.position.x)
            || (_diceTransform.position.x > _lowerWall.transform.position.x);
    }

    private bool CheckY()
    {
        return (_diceTransform.position.y < _floor.transform.position.y);
    }

    private bool CheckZ()
    {
        return (_diceTransform.position.z < _leftWall.transform.position.z)
            || (_diceTransform.position.z > _rightWall.transform.position.z);
    }
}
