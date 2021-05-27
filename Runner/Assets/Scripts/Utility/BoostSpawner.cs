using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    public GameObject[] boosts;
    public Transform spawnPoint;
    private GameObject spawned;
    private IBoost spawnedBoost;
    private void Start()
    {
        spawned = Instantiate(boosts[Random.Range(0 , boosts.Length)] , spawnPoint.position , Quaternion.identity) as GameObject;
        spawned.transform.parent = spawnPoint.parent;
        spawnedBoost = spawned.GetComponent<IBoost>();
        GameEvents.current.OnBoostTaken += OnBoostDestroyed;
    }

    public void OnBoostDestroyed(int id)
    {
        if (spawnedBoost.BoostModel == null || id == spawnedBoost.BoostModel.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        GameEvents.current.OnBoostTaken -= OnBoostDestroyed;
    }

}
