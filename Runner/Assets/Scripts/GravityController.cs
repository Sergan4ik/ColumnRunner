using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GravityController : MonoBehaviour
{
    //public Rigidbody player;
    public PlatformsController platforms;
    public float gravityMultiplier = 1;
    public Vector3 defaultGravity = Vector3.down * 10;
    [HideInInspector] public bool changeGravity = true;
    CinemachineStateDrivenCamera a;
    private void Start()
    {
        Physics.gravity = GetNextGravity() * gravityMultiplier;
    }

    private void FixedUpdate()
    {
        if (changeGravity)
        {
            Vector3 nextGravity = GetNextGravity();
            Physics.gravity = nextGravity * gravityMultiplier;
        }
    }

    public void setDefaultGravity()
    {
        Physics.gravity = defaultGravity;
        changeGravity = false;
    }

    public Vector3 GetNextGravity()
    {
        Vector3 nextGravity = platforms.currentColumn.centers.current.position - Player.instance.playerModel.position;
        nextGravity.z = 0;
        return nextGravity;
    }
}
