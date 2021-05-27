using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    Quaternion defaultCannonTransform , defaultRotatorTransform;
    public Transform cannon , rotator;
    public float maxCannonAngle = 20;
    public float playerSpeed = 0;
    [Range(0,1f)] public float Damping = 0.1f;
    [HideInInspector] public Vector3 target;
    [HideInInspector] public bool inVisionZone;
    [HideInInspector] public bool isPlayerVisible;
    private RaycastHit hit;
    private bool isHit;
    public LayerMask layerToIgnore;

    public ShootCannonBall gun;
    private void Start()
    {
        layerToIgnore = ~layerToIgnore;
        defaultCannonTransform = cannon.localRotation;
        defaultRotatorTransform = rotator.localRotation;
    }

    private void Update()
    {
        if (inVisionZone)
        {
            if (IsPlayerVisible())
            {
                RotateVertical();
                RotateHorizontal();
                isPlayerVisible = true;
            }
            else
            {
                SetDefaultPosition();
                isPlayerVisible = false;
                gun.ResetFirstShootTimer();
            }
        }
        else
        {
            gun.ResetFirstShootTimer();
            SetDefaultPosition();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(cannon.position, GetLookDirection() * 100, Color.red);
        Debug.DrawRay(cannon.position, cannon.forward * 100, Color.green);
        Debug.DrawRay(cannon.position, (GetExpectedPlayerPosition() - cannon.position) * 100, Color.magenta);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GetExpectedPlayerPosition(), 0.05f);
    }

    void RotateVertical()
    {
        //Vector3 euler , lookDirection = GetLookDirection();
        Vector3 euler , lookDirection = GetExpectedPlayerPosition() - gun.shootingPoint.position;
        euler = Quaternion.LookRotation(lookDirection).eulerAngles;
        if (euler.x > 180)
            euler.x -= 360;
        if (euler.x < -maxCannonAngle)
            euler.x = -maxCannonAngle;
        if (euler.x > maxCannonAngle)
            euler.x = maxCannonAngle;
        euler.y = 0;
        euler.z = 0;
        cannon.localRotation = Quaternion.Slerp(cannon.localRotation, Quaternion.Euler(euler), Damping * Time.deltaTime * 8);
    }

    void RotateHorizontal()
    {
        //Vector3 euler, lookDirection =  GetRotatorLookDirection();
        //lookDirection.y = 0;
        //euler = Quaternion.LookRotation(lookDirection).eulerAngles;
        //Debug.Log(euler);
        //rotator.localRotation = Quaternion.Slerp(rotator.localRotation, Quaternion.Euler(euler), Damping * Time.deltaTime * 8);
        //print(rotator.rotation.eulerAngles);
        rotator.LookAt(GetExpectedPlayerPosition());
        Vector3 euler = rotator.localRotation.eulerAngles;
        euler.x = euler.z = 0;
        rotator.localRotation = Quaternion.Euler(euler);
    }

    bool IsPlayerVisible()
    {
        isHit = Physics.Raycast(cannon.position, GetLookDirection(), out hit, Mathf.Infinity, layerToIgnore);
        if (1 << hit.collider.gameObject.layer == LayerMask.GetMask("Player"))
        {
            isHit = true;
            return true;
        }
        isHit = false;
        return false;
    }

    void SetDefaultPosition()
    {
        cannon.localRotation = Quaternion.Slerp(cannon.localRotation , defaultCannonTransform, Time.deltaTime);
        rotator.localRotation = Quaternion.Slerp(rotator.localRotation, defaultRotatorTransform, Time.deltaTime);
    }

    public Vector3 GetExpectedPlayerPosition()
    {
        Collider col;
        Vector3 result = Vector3.zero;
        float time = GetExpectedTimeToHit();
        float anticipation = playerSpeed * time;
        if (isHit)
        {
            col = hit.collider;
            result = col.transform.position;
            result.z += anticipation;
        }
        return result;
    }

    public Vector3 GetLookDirection()
    {
        return ((target - cannon.position));
    }

    public Vector3 GetRotatorLookDirection()
    {
        return ((target - rotator.position));
    }

    public float GetExpectedTimeToHit()
    {
        float timeToMeet = 1;
        if (isHit)
        {
            float distance = hit.distance;
            timeToMeet = distance / (gun.cannonBall.speed + playerSpeed);
        }
        return timeToMeet;
    }
}
