using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum MenuType
{
    MainMenu = 0, GameOverlay = 1, Settings = 2, DieMenu = 3, Shop = 4 , TapToStartScreen = 5
}

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuObjects = new List<GameObject>(Enum.GetNames(typeof(MenuType)).Length);
    [HideInInspector] GameObject activeCanvas;
    public static CanvasManager Instance;

    private void Awake()
    {
        activeCanvas = menuObjects[(int) MenuType.MainMenu];
    }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
    public void SwitchToCanvas(int menuType)
    {
        foreach(GameObject gm in menuObjects)
        {
            if (gm != null)
                gm.SetActive(false);
        }
        //if (activeCanvas != null)
        //    Instance.activeCanvas.SetActive(false);
        Instance.activeCanvas = menuObjects[menuType];
        Instance.activeCanvas.SetActive(true);
    }
    
    public void SwitchToCanvas(GameObject targetCanvas)
    {
        foreach (GameObject gm in menuObjects)
        {
            if (gm != null)
                gm.SetActive(false);
        }
        //if (activeCanvas != null)
        //    Instance.activeCanvas.SetActive(false);
        Instance.activeCanvas = targetCanvas;
        Instance.activeCanvas.SetActive(true);
    }
    public void SwitchToCanvas(MenuType targetCanvas)
    {
        foreach (GameObject gm in menuObjects)
        {
            if (gm != null)
                gm.SetActive(false);
        }
        //if (activeCanvas != null)
        //    Instance.activeCanvas.SetActive(false);
        Instance.activeCanvas = menuObjects[(int)targetCanvas];
        Instance.activeCanvas.SetActive(true);
    }
}
