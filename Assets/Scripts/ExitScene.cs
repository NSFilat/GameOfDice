using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public void CloseScene()
    {
        SceneManager.LoadScene(CurrentScene.prevIndex);
    }
}
