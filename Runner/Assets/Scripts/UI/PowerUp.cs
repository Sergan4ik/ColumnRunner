using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PowerUp : MonoBehaviour
{
    public string powerUpName;
    public int currentUp = 0, maxUp;
    public Image[] upImages;
    public int[] prices;
    public Color activeColor, baseColor;
    public TextMeshProUGUI BuyButtonText;
    [SerializeField] private Sound buySound , failSound;
    private void Start()
    {
        currentUp = PlayerPrefs.GetInt(powerUpName);
        UpdateStates();
    }
    private void Upgrade()
    {
        currentUp++;
        PlayerPrefs.SetInt(powerUpName, currentUp);
        UpdateStates();
    }
    public void TryBuy()
    {
        if (PlayerPrefs.GetInt ("Money") >= prices[currentUp] && currentUp < maxUp)
        {
            Debug.Log("Buyed " + powerUpName);
            PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - prices[currentUp]);
            Upgrade();
            AudioManager.Instance.PlaySound(buySound);
            //return true;
        }
        Debug.Log("Buy failed " + powerUpName);
        AudioManager.Instance.PlaySound(failSound);
        //return false;
    }

    public void UpdateStates()
    {
        for (int i = 0; i < upImages.Length; ++i)
        {
            if (i < currentUp)
            {
                upImages[i].color = activeColor;
            }
            else
            {
                upImages[i].color = baseColor;                
            }
        }
        if (currentUp < maxUp)
            BuyButtonText.text = prices[currentUp].ToString();
        else
            BuyButtonText.text = "Max lvl";

    }
}
