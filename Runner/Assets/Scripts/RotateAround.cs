using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform center;
    public float angle;
    public Vector3 axis = Vector3.forward;
    private float lastAngle = 0;

    private void Start()
    {
        angle = lastAngle = 0;
    }

    private void OnDrawGizmos()
    {
        float nextAngle = angle - lastAngle;
        if (center)
            this.gameObject.transform.RotateAround(center.position, axis, nextAngle);
        lastAngle = angle;
    }
}
