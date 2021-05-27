using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : MonoBehaviour
{
    public Rigidbody mainRB;
    public Rigidbody[] body;
    public void ChangeRagdollState(bool state)
    {
        mainRB.isKinematic = state;
        foreach(Rigidbody part in body)
        {
            part.isKinematic = !state;
        }
    }

}
