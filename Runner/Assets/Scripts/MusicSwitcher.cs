using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] Sound[] music;

    enum MusicType
    {
        MenuMusic , RunMusic
    }

}
