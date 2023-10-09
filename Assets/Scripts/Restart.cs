using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        GameManager.Instance.ResetScore();
        GameManager.Instance.PowerUpOff();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}