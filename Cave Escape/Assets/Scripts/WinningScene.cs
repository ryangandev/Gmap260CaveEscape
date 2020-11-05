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
