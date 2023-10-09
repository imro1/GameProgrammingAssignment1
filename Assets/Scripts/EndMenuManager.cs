using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
