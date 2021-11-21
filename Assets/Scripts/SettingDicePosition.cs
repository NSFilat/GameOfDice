using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDicePosition : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    static private float s_diceStartPosition = 0;

    static public float DiceStartPosition { set { s_diceStartPosition = value; } get { return s_diceStartPosition; } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _floor)
        {
            SetStartPosition();
            ReplaceScripts();
        }
    }

    private void SetStartPosition()
    {
        s_diceStartPosition = transform.position.y;
        transform.position = new Vector3(0f, s_diceStartPosition, 0f);
        transform.rotation = Quaternion.identity;
    }

    private void ReplaceScripts()
    {
        gameObject.AddComponent<Shaking>();
        Destroy(gameObject.GetComponent<SettingDicePosition>());
    }
}