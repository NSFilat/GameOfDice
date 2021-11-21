using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingFloor : MonoBehaviour
{
    private Transform _floor;

    [SerializeField] private Transform _upperWall;
    [SerializeField] private Transform _rightWall;

    private readonly float _floorOffset = 10f;

    void Start()
    {
        _floor = GetComponent<Transform>();

        ChangeFloorScale();
    }

    private void ChangeFloorScale()
    {
        _floor.localScale = new Vector3((Mathf.Abs(_upperWall.position.x) * 2 + 1) / _floorOffset, 1, (Mathf.Abs(_rightWall.position.z) * 2 + 1) / _floorOffset);
    }
}
