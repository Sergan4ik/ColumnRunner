using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats : CharacterStats
{
    private int score = 0;
    public float Speed { get; set; }
    public int Score { get { return score; } }
    public override void TakeDamage(int damage)
    {
        Debug.Log("Current health: " + health);
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            Die();
        }
    }
    public override bool Heal(int cnt)
    {
        return base.Heal(cnt);
    }
    public override void Die()
    {
        if (IsAlive)
        {
            Debug.Log("Died");
            IsAlive = false;
            Player.instance.Die();
        }
    }

    public void IncreaseScore(int value)
    {
        this.score += value;
        RememberHighScore();
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public void RememberHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < Score)
        PlayerPrefs.SetInt("HighScore" , Score);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
