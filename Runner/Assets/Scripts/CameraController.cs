using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public static CinemachineStateDrivenCamera stateDrivenCamera;
    public static CinemachineVirtualCamera ragdollCamera;
    private Transform cameraFollowTarget;
    private Transform cameraAimTarget;
    public GameObject ragdoll;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        if (stateDrivenCamera == null)
            stateDrivenCamera = GameObject.Find("CM StateDrivenCamera").GetComponent<CinemachineStateDrivenCamera>();
        if (ragdollCamera == null)
            ragdollCamera = GameObject.Find("RagdollCamera").GetComponent<CinemachineVirtualCamera>();
    }

    public void SetCameraLookToPlayer()
    {
        Animator anim = stateDrivenCamera.GetComponent<Animator>();
        anim.SetBool("GameStarted" , true);
    }
    public void SetCameraLookToRagdoll()
    {
        Ragdoll rgd = ragdoll.GetComponent<Ragdoll>();
        ragdollCamera.Follow = rgd.cameraFollowTarget;
        ragdollCamera.LookAt = rgd.cameraAimTarget;
        Animator anim = stateDrivenCamera.GetComponent<Animator>();
        anim.SetBool("IsAlive", false);
    }
}
