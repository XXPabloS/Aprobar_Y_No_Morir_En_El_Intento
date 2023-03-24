using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene (sceneID);
    }

    public void Salidura()
    {
        Debug.Log("He salio");
        Application.Quit();
    }
}
