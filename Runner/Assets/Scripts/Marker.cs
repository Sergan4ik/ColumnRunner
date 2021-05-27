using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public float maxScaleSize = 1;
    public float timeBetweenSpawn = 1;
    public float increaseSizeSpeed = 2;
    public List<Transform> circles;
    public GameObject circleToSpawn;
    public float duration = 2;

    private float elapsedTime = 0;
    private Coroutine spawner;
    private List<Transform> toRemove = new List<Transform>();

    private void Start()
    {
        spawner = StartCoroutine(SpawnCircle());
    }

    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float difference = Time.deltaTime * increaseSizeSpeed;
        foreach(Transform circle in circles)
        {
            Vector3 scale = circle.localScale;
            scale.x += difference;
            scale.z += difference;
            circle.localScale = scale;
            if (scale.x > maxScaleSize || scale.z > maxScaleSize)
            {
                toRemove.Add(circle);
            }
        }
       
        foreach (Transform toDestroy in toRemove)
            Destroy(toDestroy.gameObject);
        circles.RemoveAll(toRemove.Contains);
        toRemove.Clear();
        if (elapsedTime > duration)
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        StopCoroutine(spawner);
    }

    IEnumerator SpawnCircle()
    {
        while (true)
        {
            GameObject circle = Instantiate(circleToSpawn, this.transform) as GameObject;
            circles.Add(circle.transform);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
