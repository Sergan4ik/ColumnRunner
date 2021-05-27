using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyParticleColor : MonoBehaviour
{
    public ParticleSystem particle;

    private void Start()
    {
        particle.startColor = GetRandomColor();
    }
    Color GetRandomColor()
    {
        return Random.ColorHSV(0.5f , 1 , 0.5f, 1 , 0.5f, 1, 0.5f , 1);
    }
}
