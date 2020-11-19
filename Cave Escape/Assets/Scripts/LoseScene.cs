using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour
{   
    public GameObject Losescrn;
    public static bool pauseAllowed = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Losescrn.gameObject.SetActive(true);
            RisingLava.lavaRising = false;
            pauseAllowed = false;
            Destroy(other.gameObject);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        RisingLava.lavaRising = false;
        pauseAllowed = true;
        startTrigger.beginAlert = true;
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
