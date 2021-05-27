using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannonBall : MonoBehaviour
{

    [Range (0.01f , Mathf.Infinity)] public float attackSpeed = 1;
    public float firstShootDelay;
    public GameObject cannonBallObject;
    public Transform shootingPoint;
    public RotateCannon cannonRotator;
    [HideInInspector]public CannonBall cannonBall;
    public GameObject marker;
    public LayerMask groundLayer;
    [HideInInspector]public bool isActive = true;

    private bool CR_Running = false;
    private Coroutine CR_Shoot;
    private float currentTimeToFirstShoot;
    private void Start()
    {
        ResetFirstShootTimer();
        cannonBall = cannonBallObject.GetComponent<CannonBall>();
    }

    private void Update()
    {
        isActive = Player.instance.playerStats.IsAlive;

        if (isActive)
        {
            if (currentTimeToFirstShoot > 0)
            {
                currentTimeToFirstShoot -= Time.deltaTime;
            }
            else
            {
                if (!CR_Running)
                {
                    CR_Shoot = StartCoroutine(Shoot());
                    CR_Running = true;
                }
            }
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (cannonRotator.isPlayerVisible && cannonRotator.inVisionZone && WillBallOnGroundLayer())
            {
                SpawnMarker();
                cannonBall.direction = (GetLandingBallPoint() - shootingPoint.position).normalized;
                yield return new WaitForSeconds(cannonRotator.GetExpectedTimeToHit() / 2);
                //cannonBall.direction = (cannonRotator.GetExpectedPlayerPosition() - cannonRotator.cannon.position).normalized;
                Instantiate(cannonBallObject, shootingPoint.position , Quaternion.identity);
                yield return new WaitForSeconds(1 / attackSpeed);
            }
            else
            {

                yield return null;
            }
        }
    }


    private void OnDestroy()
    {
        if (CR_Shoot != null)
            StopCoroutine(CR_Shoot);
    }

    void SpawnMarker()
    {
        Vector3 spawnPoint = GetLandingBallPoint();
        float angle = GetMarkerRotateAngle();
        marker.GetComponent<Marker>().duration = cannonRotator.GetExpectedTimeToHit() * 1.5f;
        GameObject s_m = Instantiate(marker, spawnPoint, Quaternion.Euler(0, 0, angle)) as GameObject;
        bool trash;
        RaycastHit hit = GetLandingBallInfo(out trash);
        if (trash)
        {
            s_m.transform.parent = hit.transform;
        }
        
    }

    float GetMarkerRotateAngle()
    {
        Vector3 expectedPos = cannonRotator.GetExpectedPlayerPosition();
        Debug.DrawRay(cannonRotator.cannon.position, expectedPos - cannonRotator.cannon.position, Color.magenta);
        RaycastHit hit;
        float angle = 0;
        if (Physics.Raycast(cannonRotator.cannon.position, expectedPos - cannonRotator.cannon.position, out hit, Mathf.Infinity, groundLayer))
        {
            angle = Vector3.SignedAngle(Vector3.up, hit.normal, Vector3.forward);
        }
        return angle;
    }

    RaycastHit GetLandingBallInfo(out bool isHitted)
    {
        Vector3 expectedPos = cannonRotator.GetExpectedPlayerPosition();
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(cannonRotator.cannon.position, expectedPos - cannonRotator.cannon.position, out hit, Mathf.Infinity, groundLayer))
        {
            isHitted = true;
            return hit;
        }

        isHitted = false;
        return hit;
    }
    Vector3 GetLandingBallPoint()
    {
        bool hitted;
        RaycastHit info = GetLandingBallInfo(out hitted);
        if (hitted)
        {
            return info.point;
        }

        return Vector3.zero;
    }

    bool WillBallOnGroundLayer()
    {
        Vector3 expectedPos = cannonRotator.GetExpectedPlayerPosition();
        return Physics.Raycast(cannonRotator.cannon.position, expectedPos - cannonRotator.cannon.position, groundLayer);
    }

    public void ResetFirstShootTimer()
    {
        currentTimeToFirstShoot = firstShootDelay;
    }
}
