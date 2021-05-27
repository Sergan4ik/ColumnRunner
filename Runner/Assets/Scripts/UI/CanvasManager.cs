using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum MenuType
{
    MainMenu = 0, UI = 1, Settings = 2, DieMenu = 3, Shop = 4
}

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuObjects = new List<GameObject>(Enum.GetNames(typeof(MenuType)).Length);
    [HideInInspector] GameObject activeCanvas;
    public static CanvasManager Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
    public void SwitchToCanvas(int menuType)
    {
        Instance.activeCanvas.SetActive(false);
        Instance.activeCanvas = Instance.menuObjects[menuType];
        Instance.activeCanvas.SetActive(true);
    }
}
