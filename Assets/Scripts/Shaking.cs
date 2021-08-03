using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private Renderer _diceRenderer;
    private Vector3 default_position;

    [SerializeField] private float jumpForce = 200f;
    [SerializeField] private float begin_speed = 5f;
    [SerializeField] private float end_speed = 5f;

    private void Start()
    {
        _diceRigidbody = GetComponent<Rigidbody>();
        _diceRenderer = GetComponent<Renderer>();

        _diceRigidbody.maxAngularVelocity = Mathf.Infinity;
        default_position = GetComponent<PreparationForShaking>().Default_position;
        Debug.Log($"Shaking {default_position} ");

        StartCoroutine(ShakingCoroutine());
    }

    bool IsStart = true;
    bool IsMoved = true;
    IEnumerator ShakingCoroutine()
    {
        IsStart = true;
        IsMoved = true;

        float speed = _diceRigidbody.velocity.magnitude;

        while (IsStart)
        {
            _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - default_position.z, 0f, Input.acceleration.x - default_position.x) * jumpForce);
            Debug.Log("---------");
            if (speed > begin_speed) IsStart = false;
            yield return null;
        }

        while (IsMoved)
        {
            _diceRigidbody.AddForce(new Vector3(Input.acceleration.z - default_position.z, 0f, Input.acceleration.x - default_position.x) * jumpForce);
            Debug.Log("++++++");
            if (speed < end_speed) IsMoved = !IsMoved;
            yield return null;
        }
    }
    

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        //GUILayout.Label("Input.acceleration: " + Input.acceleration);
        GUI.Label(new Rect(0, 0, 300, 100), "Default position: " + default_position, myStyle);
        GUI.Label(new Rect(0, 40, 300, 100), "Input.acceleration: " + Input.acceleration, myStyle);
        GUI.Label(new Rect(0, 80, 300, 100), "IsStart: " + IsStart, myStyle);
        GUI.Label(new Rect(0, 120, 300, 100), "IsMoved: " + IsMoved, myStyle);
        GUI.Label(new Rect(0, 160, 300, 100), "Speed: " + _diceRigidbody.velocity.magnitude, myStyle);

    }
}
