using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IBoost
{
    public Transform boostModel;
    public int goldCount = 1;
    public Transform BoostModel { get { return boostModel; } set { boostModel = value; } }
    [SerializeField] private Sound coinTakeSound;
    private void Start()
    {
        GameEvents.current.OnBoostTaken += OnBoostTaken;
    }

    public void OnBoostTaken(int id)
    {
        if (id == boostModel.gameObject.GetInstanceID())
        {
            AudioManager.Instance.PlaySound(coinTakeSound);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + goldCount);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.OnBoostTaken -= OnBoostTaken;
    }
}
