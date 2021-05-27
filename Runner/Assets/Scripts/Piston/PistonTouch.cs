using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonTouch : MonoBehaviour
{
    public GravityController gravityController;
    public Transform pistonCollider;
    public Rigidbody playerRigidbody;
    public int playerLayer;
    public float forcePower;
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.layer == playerLayer)
        {
            playerRigidbody.AddForce(pistonCollider.up * forcePower , ForceMode.Acceleration);
            gravityController.setDefaultGravity();
        }
    }

}
