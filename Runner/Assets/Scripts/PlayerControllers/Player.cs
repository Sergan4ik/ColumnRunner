using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlatformsController platformsController;
    public PlayerJumpScript jump;
    public PlayerRotationController rotationController;
    public Animator playerAnimator;
    public PlayerStats playerStats;

    public Transform playerModel;
    public Ragdoll ragdoll;
    public static Player instance { get; set; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
    }
    private void Update()
    {
        #region Left/Right
        /*if (SwipeManager.swipeLeft)
        {
            platformsController.GoLeft();
        }
        if (SwipeManager.swipeRight)
        {
            platformsController.GoRight();
        }*/
        #endregion


        #region Rotation
        rotationController.Rotate();
        #endregion

        #region Jump
        jump.isFalling = !jump.GroundCheck();
        if (SwipeManager.swipeUp && !jump.isFalling)
        {
            playerAnimator.SetTrigger("Jump");
            jump.Jump();
        }
        #endregion

        #region Roll
        if (!jump.isFalling && SwipeManager.swipeDown)
        {
            playerAnimator.SetTrigger("Roll");
        }
        #endregion
    }

    public void StartRun()
    {
        playerStats.ChangeMaxHealth(PlayerPrefs.GetInt("MaxHealth"));
        playerAnimator.SetBool("isRunning", true);
    }

    public void Die()
    {
        GameEvents.current.GameEnded();
        
        playerModel.gameObject.SetActive(false);
        
        GameObject curRagdoll = Instantiate(ragdoll.ragdoll, playerModel.transform.position , Quaternion.identity) as GameObject;
        CameraController.Instance.ragdoll = curRagdoll;
        CameraController.Instance.SetCameraLookToRagdoll();
        curRagdoll.transform.parent = this.transform;

        
        StartCoroutine(SwitchToDieMenu());
        
    }

    IEnumerator SwitchToDieMenu()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        CanvasManager.Instance.SwitchToCanvas(MenuType.DieMenu);
    }
}
