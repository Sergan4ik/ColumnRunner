using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool gameStarted = false , gamePaused = false;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("MaxHealth") < 1)
            PlayerPrefs.SetInt("MaxHealth" , 1);
    }
    

    public void StartGame()
    {
        Debug.Log("Game Started");
        GameEvents.current.GameStarted();
        CanvasManager.Instance.SwitchToCanvas(MenuType.GameOverlay);
        gameStarted = true;
        Player.instance.StartRun();
        CameraController.Instance.SetCameraLookToPlayer();
    }

    public void UnPauseGame(float timeScale = 1.0f)
    {
        GameEvents.current.GameUnpaused();
        Time.timeScale = timeScale;
        gamePaused = false;
    }
    
    public void PauseGame()
    {
        GameEvents.current.GamePaused();
        Time.timeScale = 0;
        gamePaused = true;
    }
}
