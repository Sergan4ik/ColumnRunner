using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRotationController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform leftMarker , middleMarker , rightMarker;

    public PlatformsController platformsController;
    public PlayerJumpScript jumpController;

    public float rotationCoefficientInJump = 0.4f;
    public float deegresPerSecond = 45f;
    
    public AnimationCurve dependingSpeedCoefByAcceleration;

    public bool mirror = true;

    public bool keyBoard = false;
    [HideInInspector] public float rotationCoefficient = 0;

    [HideInInspector] public float currentDeegresRotation = 0;

    public void Rotate()
    {
        if (!keyBoard)
        {
            rotationCoefficient = dependingSpeedCoefByAcceleration.Evaluate(Input.acceleration.x * ((mirror) ? -1 : 1));
        }
        else
        {
            rotationCoefficient = Input.GetAxis("Horizontal");
        }
        float deegres = rotationCoefficient * deegresPerSecond * Time.deltaTime;
        if (jumpController.isFalling)
            deegres *= rotationCoefficientInJump;
        currentDeegresRotation += deegres;
        CurrentColumnRotation(deegres);
        LeftColumnRotation(-deegres);
        RightColumnRotation(-deegres);


        if (currentDeegresRotation < -360)
            currentDeegresRotation += 360;
        if (currentDeegresRotation > 360)
            currentDeegresRotation -= 360;

    }

    public void CurrentColumnRotation(float deegres)
    {
        middleMarker.RotateAround(platformsController.currentColumn.centers.current.position, platformsController.currentColumn.centers.current.up, deegres);
        playerTransform.RotateAround(platformsController.currentColumn.centers.current.position , platformsController.currentColumn.centers.current.up , deegres);
    }
    public void LeftColumnRotation(float deegres)
    {
        leftMarker.RotateAround(platformsController.currentColumn.centers.left.position, platformsController.currentColumn.centers.left.up, deegres);
    }

    public void RightColumnRotation(float deegres)
    {
        rightMarker.RotateAround(platformsController.currentColumn.centers.right.position, platformsController.currentColumn.centers.right.up, deegres);
    }
}
