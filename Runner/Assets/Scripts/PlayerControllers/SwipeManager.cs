using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool swipeLeft, swipeRight, swipeUp, swipeDown;

    public static float swipeSensetivity = 50f, swipeDistanceDeadZone = 30f , swipeTimeDeadZone = 0.5f;

    public static float elapsedTimeFromSwipeStart;
    public static Vector2 swipeVector;
    public static bool swipeBlock;
    public static Vector2 startTouchPosition, currentTouchPosition, endTouchPosition;

    private void Start()
    {
        ResetSwipeStatus();
        swipeBlock = false;
        elapsedTimeFromSwipeStart = 0f;
    }

    private void Update()
    {
        ResetSwipeStatus();
        elapsedTimeFromSwipeStart += Time.deltaTime;

        if (TouchBegan())
        {
            startTouchPosition = Input.GetTouch(0).position;
            elapsedTimeFromSwipeStart = 0;
        }
        if(TouchMoved())
        {
            currentTouchPosition = Input.GetTouch(0).position;
            if (!swipeBlock)
            {
                Vector2 swipeDirection = currentTouchPosition - startTouchPosition;
                if (!SwipeInDistanceDeadZone(swipeDirection) && !SwipeInTimeDeadZone())
                {
                    swipeVector = GetSwipeDirection(swipeDirection);
                    swipeBlock = true;
                }
            }
        }
        if (TouchEnded())
        {
            swipeBlock = false;
            endTouchPosition = Input.GetTouch(0).position;
            elapsedTimeFromSwipeStart = 0;
        }
    }

    private Vector2 GetSwipeDirection(Vector2 swipeDirection)
    {
        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            if (swipeDirection.x > 0)
            {
                swipeRight = true;
                return Vector2.right;
            }
            else
            {
                swipeLeft = true;
                return Vector2.left;
            }
        }
        else
        {
            if (swipeDirection.y > 0)
            {
                swipeUp = true;
                return Vector2.up;
            }
            else
            {
                swipeDown = true;
                return Vector2.down;
            }
        }
    }

    private bool SwipeInDistanceDeadZone(Vector2 swipeDirection)
    {
        return swipeDirection.magnitude <= swipeDistanceDeadZone;
    }

    private bool SwipeInTimeDeadZone()
    {
        return elapsedTimeFromSwipeStart > swipeTimeDeadZone;
    }

    #region Swipe Phase Detectors

    private bool TouchBegan()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    private bool TouchMoved()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
    }

    private bool TouchEnded()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    }
    #endregion

    private void ResetSwipeStatus()
    {
        swipeVector = Vector2.zero;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;
    }
} 
