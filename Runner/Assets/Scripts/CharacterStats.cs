using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    protected int health;
    public bool IsAlive { get; set; } = true;
    public float Health { get { return health; } }

    private void Awake()
    {
        health = maxHealth;
    }
    public virtual void TakeDamage(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            Die();
        }
        Debug.Log("Current health: " + health);
    }
    public float GetNormalizedHealth()
    {
        return (float)health / maxHealth;
    }
    public virtual bool Heal(int cnt)
    {
        if (health + cnt <= maxHealth)
        {
            health += cnt;
            return true;
        }
        else
        {
            health = maxHealth;
            Debug.Log("Character can't heal anymore");
            return false;
        }
    }

    public virtual void Die()
    {
        IsAlive = false;
    }
}
