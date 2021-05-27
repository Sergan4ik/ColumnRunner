using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static World Instance;
    public static float worldSpeed = 2.5f;
    public GameObject[] terrain;
    [SerializeField] private Transform spawnPoint , parentSpawned;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
    public void SpawnNewColumn()
    {
        GameObject newTerrain = Instantiate(terrain[GetRandomTerrainIDX()] , parentSpawned) as GameObject;
        newTerrain.transform.position = spawnPoint.position;
    }

    private int GetRandomTerrainIDX()
    {
        return Random.Range(0, terrain.Length);
    }
}
