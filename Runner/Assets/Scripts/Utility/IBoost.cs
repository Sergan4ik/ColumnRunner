using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoost
{
    public Transform BoostModel { get; set; }
    void OnBoostTaken(int id);
}
