using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
        Debug.Log("awaked");
    }
    public event Action<int> OnBoostTaken;
    public void BoostTaken(int id)
    {
        OnBoostTaken?.Invoke(id);
    }
}
