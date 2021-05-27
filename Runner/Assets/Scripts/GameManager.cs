using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameStarted = false , gamePaused = false;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        Time.timeScale = 1;
    }
    

    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
            StartGame();
    }

    public void StartGame()
    {
        gameStarted = true;
        Player.instance.StartRun();
        CameraController.Instance.SetCameraLookToPlayer();
    }

    public void UnPauseGame(float timeScale = 1.0f)
    {
        Time.timeScale = timeScale;
        gamePaused = false;
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
    }
}
