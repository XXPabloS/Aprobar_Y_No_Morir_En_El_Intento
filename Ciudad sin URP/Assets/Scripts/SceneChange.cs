using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MoveToScene()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void MoveToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Salidura()
    {
        Debug.Log("He salio");
        Application.Quit();
    }
}
