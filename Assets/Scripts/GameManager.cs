using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float NbOfPU = 0;
    public float CurrentNbOfPU = 0;
    public float Score = 0;
    public float CurrentScore = 0;
    public bool PowerUp = false;
    public bool hasPowerUp = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(Instance);
    }

    public void IncrementNbOfPu()
    {
        NbOfPU += 1;
    }

    public void LevelCompleted()
    {
        CurrentScore = Score;
        CurrentNbOfPU = NbOfPU;
    }

    public void IncrementScore()
    {
        Score += 50;
    }

    public void ResetScore()
    {
        Score = CurrentScore;
    }

    public void PowerUpOn()
    {
        PowerUp = true;
    }

    public void PowerUpOff()
    {
        PowerUp = false;
    }
}
