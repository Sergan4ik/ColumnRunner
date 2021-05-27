using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public TwoColorGradient textGradient;
    public float changeSpeed = 0.1f;
    private void Update()
    {
        UpdateHealthBar();
        UpdateHelthText();
    }

    private void UpdateHelthText()
    {
        healthText.text = Player.instance.playerStats.Health.ToString();
        healthText.color = textGradient.Evaluete(Player.instance.playerStats.GetNormalizedHealth());
    }

    void UpdateHealthBar()
    {
        float nextFillAmount = Mathf.Lerp(healthBar.fillAmount , Player.instance.playerStats.GetNormalizedHealth() , changeSpeed);
        healthBar.fillAmount = nextFillAmount;
    }
}
