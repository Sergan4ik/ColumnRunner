using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownBoost : MonoBehaviour , IBoost
{
    public Transform boostModel;
    public float duration = 5;
    public float slowScale = 2;
    public Transform BoostModel { get; set; }
    private void Start()
    {
        GameEvents.current.OnBoostTaken += OnBoostTaken;
    }
    public void OnBoostTaken(int id)
    {
        if (boostModel.gameObject.GetInstanceID() == id)
        {
            StartCoroutine(TimeSlow());
            boostModel.gameObject.SetActive(false);
        }
    }

    IEnumerator TimeSlow()
    {
        Debug.Log("start slow");
        if (slowScale != 0)
        {
            Time.timeScale = 1.0f / slowScale;
        }
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
        Debug.Log("end slow");
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        GameEvents.current.OnBoostTaken -= OnBoostTaken;
    }
}
