using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlatformsController : MonoBehaviour
{
    public Transform markersTransform , playerModelTransform;

    public Transform leftMarker , middleMarker, rightMarker;

    public PlayerRotationController rotationController;

    public Column currentColumn;


    public int currentPlatformIndex = 0 , leftSidePlatforms = 1 , rightSidePlatforms = 1;
    public bool GoLeft()
    {
        if (leftSidePlatforms > 0)
        {
            Vector3 leftOffset = currentColumn.leftColumn.centers.left.position - currentColumn.centers.left.position;
            Vector3 middleOffset = currentColumn.centers.left.position - currentColumn.centers.current.position;
            Vector3 rightOffset = currentColumn.centers.current.position - currentColumn.centers.right.position;

            leftMarker.position += leftOffset;
            middleMarker.position += middleOffset;
            playerModelTransform.position += middleOffset;
            rightMarker.position += rightOffset;

            //Vector3 offset = currentColumn.centers.left.position - currentColumn.centers.current.position;
            //markersTransform.position += offset;

            currentColumn = currentColumn.leftColumn;

            rotationController.CurrentColumnRotation(-2 * rotationController.currentDeegresRotation);
            rotationController.LeftColumnRotation(2 * rotationController.currentDeegresRotation);
            rotationController.RightColumnRotation(2 * rotationController.currentDeegresRotation);
            

            rotationController.currentDeegresRotation = rotationController.currentDeegresRotation * -1;

            leftSidePlatforms--;
            rightSidePlatforms++;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GoRight()
    {
        if (rightSidePlatforms > 0)
        {
            Vector3 leftOffset = currentColumn.centers.current.position - currentColumn.centers.left.position;
            Vector3 middleOffset = currentColumn.centers.right.position - currentColumn.centers.current.position;
            Vector3 rightOffset = currentColumn.rightColumn.centers.right.position - currentColumn.centers.right.position;

            leftMarker.position += leftOffset;
            middleMarker.position += middleOffset;
            playerModelTransform.position += middleOffset;
            rightMarker.position += rightOffset;

            //Vector3 offset = currentColumn.centers.right.position - currentColumn.centers.current.position;
            //markersTransform.position += offset;

            currentColumn = currentColumn.rightColumn;
            
            rotationController.CurrentColumnRotation(-2 * rotationController.currentDeegresRotation);
            rotationController.LeftColumnRotation(2 * rotationController.currentDeegresRotation);
            rotationController.RightColumnRotation(2 * rotationController.currentDeegresRotation);


            rotationController.currentDeegresRotation = rotationController.currentDeegresRotation * -1;
            leftSidePlatforms++;
            rightSidePlatforms--;

            return true;
        }
        else
        {
            return false;
        }
    }
}
