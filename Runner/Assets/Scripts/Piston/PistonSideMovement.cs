using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonSideMovement : MonoBehaviour
{
    public Transform pistonSide;
    public AnimationCurve speedCoefDependingOfTime;
    public bool mirror = false;
    public float cooldown = 0.3f;
    public float maxUnitsOffset = 1;
    public float maxWaveTime = 2;
    private float lastTime = 0;
    private bool ifCoolDown = false;
    private float currentCooldownTime = 0;
    private float lastOffset = 0;
    private void Update()
    {
        if (currentCooldownTime > cooldown)
        {
            currentCooldownTime = 0;
            ifCoolDown = false;
        }
        if (lastTime > maxWaveTime)
        {
            lastTime = 0;
            ifCoolDown = true;
        }
        if (!ifCoolDown)
        {
            float coef = speedCoefDependingOfTime.Evaluate(lastTime / maxWaveTime * 2);
            float nextMove = (coef * maxUnitsOffset) - lastOffset;

            pistonSide.Translate(Vector3.up * nextMove);
            lastOffset += nextMove;
            lastTime += Time.deltaTime;
        }
        else
        {
            currentCooldownTime += Time.deltaTime;
        }
    }
}
