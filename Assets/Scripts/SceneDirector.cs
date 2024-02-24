using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneDirector : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    private Score _score;
    private Plane _plane;

    private void Start()
    {
        _plane = FindObjectOfType<Plane>();
        _score = FindObjectOfType<Score>();
    }

    public void EndGame()
    {
        // freeze time
        Time.timeScale = 0;
        // activate image Game Over
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1;
        _plane.Restart();
        DestroyObstacle();
        _score.RestartScore();
    }

    private void DestroyObstacle()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.DestroyObject();
        }
    }
}
