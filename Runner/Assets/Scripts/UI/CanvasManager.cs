using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MenuType
{
    MainMenu, UI, Settings, DieMenu, Shop
}

public class CanvasManager : MonoBehaviour
{   
    public MenuType mt;
}
