using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthbarBehaviour healthbar;

    void Start()
    {
        health = maxHealth;
        healthbar.SetHealth(health, maxHealth);
    }

    void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthbar.SetHealth(health, maxHealth);
        Debug.Log(health);
    }
}
