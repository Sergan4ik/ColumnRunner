using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoColorGradient : MonoBehaviour
{
    Gradient gradient;
    public Color color1, color2;
    [Range(0, 1)]public float alpha1, alpha2;
    public float test;
    private void Start()
    {
        gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        colorKeys[0].color = color1;
        colorKeys[0].time = 0;
        colorKeys[1].color = color2;
        colorKeys[1].time = 1;

        alphaKeys[0].alpha = alpha1;
        alphaKeys[0].time = 0;
        alphaKeys[1].alpha = alpha2;
        alphaKeys[1].time = 1;
        gradient.SetKeys(colorKeys, alphaKeys);
    }
    private void Update()
    {
        //Debug.Log(Evaluete(test));
    }
    public Color Evaluete(float time)
    {
        return gradient.Evaluate(time);
    }
}
