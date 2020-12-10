using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomStatus : MonoBehaviour
{
    public static int health;
    public int maxHealth;
    public PomHealthbar healthbar;

    public GameObject Losescrn2;

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
            Losescrn2.gameObject.SetActive(true);
            RisingLava.lavaRising = false;
            LoseScene.pauseAllowed = false;
            SoundManager.PlaySound("lose");
        }
        
    }

    public void PlayerTakeDamage(int damage){
        health -= damage;
        healthbar.SetHealth(health, maxHealth);
        Debug.Log(health + " health remain");
    }
}
