using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class StartButton_Click : MonoBehaviour
{
    public GameObject startBtn;

    public void StartClick()
    {
        EditorSceneManager.LoadScene("scene_mikkel");
    }
}


