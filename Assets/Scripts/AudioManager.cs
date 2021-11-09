using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource DiceRollingSound;
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private GameObject _upperWall;
    [SerializeField] private GameObject _lowerWall;
    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _leftWall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _upperWall || collision.gameObject == _lowerWall || collision.gameObject == _rightWall || collision.gameObject == _leftWall)
        {
            if(!DiceRollingSound.isPlaying)
                DiceRollingSound.PlayOneShot(audioClip);
        }
    }
}
