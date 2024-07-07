using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneId)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneId);
        Time.timeScale = 1;
    }
}
