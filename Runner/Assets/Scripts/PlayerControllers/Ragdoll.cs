using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[System.Serializable]
public class Ragdoll : MonoBehaviour
{
    public static CinemachineStateDrivenCamera stateDrivenCamera;
    public static CinemachineVirtualCamera ragdollCamera;
    public Transform cameraFollowTarget;
    public Transform cameraAimTarget;
    public GameObject ragdoll;

    private void Awake()
    {
        if (stateDrivenCamera == null)
            stateDrivenCamera = GameObject.Find("CM StateDrivenCamera").GetComponent<CinemachineStateDrivenCamera>();
        if (ragdollCamera == null)
            ragdollCamera = GameObject.Find("RagdollCamera").GetComponent<CinemachineVirtualCamera>();
    }

    public void SetCameraLook()
    {
        ragdollCamera.Follow = cameraFollowTarget;
        ragdollCamera.LookAt = cameraAimTarget;
        Animator anim = stateDrivenCamera.GetComponent<Animator>();
        anim.SetBool("IsAlive", false);
    }
}
