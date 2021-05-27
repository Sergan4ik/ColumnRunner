using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public LayerMask layerToDetect;
    public string playerName;
    public RotateCannon cannonRotator;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != layerToDetect.value && other.gameObject.name == playerName)
        {
            cannonRotator.inVisionZone = true;
            cannonRotator.target = other.transform.position;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != layerToDetect.value && other.gameObject.name == playerName)
        {
            cannonRotator.inVisionZone = false;
        }
    }
}
