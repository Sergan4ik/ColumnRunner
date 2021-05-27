using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTakeArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player.instance.gameObject.layer)
        {
            GameEvents.current.BoostTaken(this.gameObject.GetInstanceID());
        }
    }
}
