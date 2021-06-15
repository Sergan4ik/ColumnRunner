using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BalanceUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI balanceText;
    void Update()
    {
        balanceText.text = PlayerPrefs.GetInt("Money").ToString();
    }
}
