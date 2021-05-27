using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerJumpScript : MonoBehaviour
{
    public float gizmosOffset;
    public float checkGroundRadius;
    public LayerMask layersToDetect;
    public float jumpHeight = 1;
    public Rigidbody rb;
    public PlatformsController platforms;
    [HideInInspector] public bool isFalling = false;
    

    public void Jump()
    {
        Vector3 velocity = (-Physics.gravity.normalized) * Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpHeight);
        rb.velocity = velocity;
    }

    public Vector3 GetPointForCheck()
    {
        Vector3 point = Vector3.Lerp(rb.position, platforms.currentColumn.centers.current.position, gizmosOffset);
        point.z = rb.position.z;
        return point;
    }

    public bool GroundCheck()
    {
        return Physics.CheckSphere(GetPointForCheck() , checkGroundRadius , layersToDetect);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GetPointForCheck() , checkGroundRadius);
    }
}
