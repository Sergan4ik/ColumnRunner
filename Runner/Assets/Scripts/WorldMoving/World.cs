using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerable = System.Linq.Enumerable;
using Random = UnityEngine.Random;

public class World : MonoBehaviour
{
    public static World Instance;
    public static float worldSpeed = 2.5f;
    [HideInInspector] public float startWorldSpeed;
    public GameObject[] terrain;
    [Header("World speed by time")] [SerializeField] private AnimationCurve dependency;
    [SerializeField] private Transform spawnPoint , parentSpawned;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            startWorldSpeed = worldSpeed;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameStarted)
        {
            worldSpeed = startWorldSpeed *
                         dependency.Evaluate(Mathf.Min(Mathf.Max(Time.time - GameManager.Instance.gameStartTime, 0),
                             dependency.keys[dependency.keys.Length - 1].time));
        }
    }

    public void SpawnNewColumn()
    {
        GameObject newTerrain = Instantiate(terrain[GetRandomTerrainIdx()] , parentSpawned) as GameObject;
        newTerrain.transform.position = spawnPoint.position;
    }

    private int GetRandomTerrainIdx()
    {
        return Random.Range(0, terrain.Length);
    }

    public float GetMaxSpeedCoef()
    {
        return dependency.keys[dependency.length - 1].value;
    }

    public float GetCurrentSpeedCoef()
    {
        return (float)worldSpeed / startWorldSpeed;
    }
}
