using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public static float fps;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS: " + (int)fps);
        GUILayout.Label("FPS: " + (int)fps);
        GUILayout.Label("FPS: " + (int)fps);
        GUILayout.Label("FPS: " + (int)fps);
        GUILayout.Label("FPS: " + (int)fps);
        GUILayout.Label("FPS: " + (int)fps);

    }
}
