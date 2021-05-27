using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenterOfMass : MonoBehaviour
{
    public Rigidbody targetRigidbody = null;
    public Transform  targetPosition = null;
    [Header("Debug")]
    public float radiusCheckSphere = 0.1f;

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawSphere(targetRigidbody.centerOfMass, radiusCheckSphere);
        }
        else
        {
            Gizmos.DrawSphere(targetPosition.position, radiusCheckSphere);
        }
    }

    private void Update()
    {
        targetRigidbody.centerOfMass = targetPosition.position;
    }
}
