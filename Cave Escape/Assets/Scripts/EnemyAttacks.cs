using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PomStatus>().PlayerTakeDamage(damage);
            SoundManager.PlaySound("hurt");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
