using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour
{   
    public GameObject Losescrn;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Losescrn.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
