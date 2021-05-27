using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DestructionArea : MonoBehaviour
{
    public LayerMask toDetect;

    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == toDetect)
        {
            Delete(other.gameObject);
        }
    }
    void Delete(GameObject toDelete)
    {
        Transform parent = toDelete.transform.parent;
        Destroy(parent.gameObject);
    }
}
