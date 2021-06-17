using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        if (current == null)
            current = this;
    }
    public event Action<int> OnBoostTaken;
    public void BoostTaken(int id)
    {
        OnBoostTaken?.Invoke(id);
    }

    public event Action OnGameStarted;
    public void GameStarted()
    {
        OnGameStarted?.Invoke();
    }
    public event Action OnGameEnded;
    public void GameEnded()
    {
        OnGameEnded?.Invoke();
    }
    
    public event Action OnGamePaused;

    public void GamePaused()
    {
        OnGamePaused?.Invoke();
    }
    
    public event Action OnGameUnpaused;

    public void GameUnpaused()
    {
        OnGameUnpaused?.Invoke();
    }
    
}
