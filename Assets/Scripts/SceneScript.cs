using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
