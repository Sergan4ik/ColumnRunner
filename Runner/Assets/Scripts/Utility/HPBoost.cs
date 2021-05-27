using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBoost : MonoBehaviour , IBoost
{
    public Transform boostModel;
    public Transform BoostModel { get { return boostModel; } set { boostModel = value; } }

    private void Start()
    {
        GameEvents.current.OnBoostTaken += OnBoostTaken;
    }
    public void OnBoostTaken(int id)
    {
        if (id == boostModel.gameObject.GetInstanceID())
        {
            if (Player.instance.playerStats.Heal(1))
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        GameEvents.current.OnBoostTaken -= OnBoostTaken;
    }
}
