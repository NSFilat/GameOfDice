using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    private Rigidbody _diceRigidbody;
    private Renderer _diceRenderer;
    private Vector3 default_position;

    [SerializeField] private float jumpForce = 200f;
    [SerializeField] private float begin_speed = 15f;
    [SerializeField] private float end_speed = 1f;

    private void Start()
    {
        _diceRigidbody = GetComponent<Rigidbody>();
        _diceRenderer = GetComponent<Renderer>();

        _diceRigidbody.maxAngularVelocity = Mathf.Infinity;
        Debug.Log($"Shaking {default_position} ");
        //StartCoroutine(PreparationCoroutine());
        //StartCoroutine(ShakingCoroutine());
    }

    /*
    IEnumerator PreparationCoroutine()
    {
        while (Input.acceleration == Vector3.zero)
        {
            yield return null;
        }

        default_position = Input.acceleration;
        Debug.Log(default_position);
    }
        
    bool IsStart = true;
    bool IsMoved = true;
    IEnumerator ShakingCoroutine()
    {
        IsStart = true;
        IsMoved = true;

        //float speed = _diceRigidbody.velocity.magnitude;

        while (IsStart)
        {
            if(_diceRigidbody.velocity.magnitude == 0)
            _diceRigidbody.AddForce(new Vector3(default_position.z + Input.acceleration.z , 0f, default_position.x + Input.acceleration.x) * jumpForce);
            Debug.Log("---------");
            if (_diceRigidbody.velocity.magnitude > begin_speed) IsStart = false;
            yield return null;
        }

        while (IsMoved)
        {
            _diceRigidbody.AddForce(new Vector3(default_position.z + Input.acceleration.z, 0f, default_position.x + Input.acceleration.x) * jumpForce);
            Debug.Log("++++++");
            if (_diceRigidbody.velocity.magnitude < end_speed) IsMoved = !IsMoved;
            yield return null;
        }

        StartCoroutine(PreparationCoroutine());
        StartCoroutine(ShakingCoroutine());
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
    */
}
