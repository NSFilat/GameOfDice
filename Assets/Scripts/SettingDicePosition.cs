using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDicePosition : MonoBehaviour
{
    [SerializeField] private GameObject _floor;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == _floor)
        {
            SetStartPosition();
            ReplaceScripts();
        }
    }

    private void SetStartPosition()
    {
        transform.position = new Vector3(0f, transform.position.y, 0f);
        transform.rotation = Quaternion.identity;
    }

    private void ReplaceScripts()
    {
        gameObject.AddComponent<Shaking>();
        Destroy(gameObject.GetComponent<SettingDicePosition>());
    }
}
