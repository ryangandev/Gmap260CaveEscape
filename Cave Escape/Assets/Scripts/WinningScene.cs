using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScene : MonoBehaviour
{
    public GameObject Endscrn;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Endscrn.gameObject.SetActive(true);
            LoseScene.pauseAllowed = false;
            RisingLava.lavaRising = false;
            Destroy(other.gameObject);
            SoundManager.PlaySound("win");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        LoseScene.pauseAllowed = true;
        RisingLava.lavaRising = false;
        startTrigger.beginAlert = true;
        Physics2D.IgnoreLayerCollision(10, 9, false);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }  
}
