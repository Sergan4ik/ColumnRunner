using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnPoint : MonoBehaviour
{
    private bool spawnTrigger = false;
    public float radiusCheckSphere = 1;
    public LayerMask terrainLayer;
    private void Start()
    {
        print(terrainLayer.value);
    }

    private void Update()
    {
        if (spawnTrigger)
        {
            spawnTrigger = false;
            World.Instance.SpawnNewColumn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) == terrainLayer)
        {
            spawnTrigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) == terrainLayer)
        {
            spawnTrigger = true;
        }
    }
}
