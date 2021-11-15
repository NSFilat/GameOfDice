using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentScene : MonoBehaviour
{
    public static int prevIndex;
    public static int Index;

    private void Start()
    {
        prevIndex = Index;
        Index = SceneManager.GetActiveScene().buildIndex;
    }


}
