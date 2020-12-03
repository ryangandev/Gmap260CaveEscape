using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        RisingLava.lavaRising = false;
        LoseScene.pauseAllowed = true;
        startTrigger.beginAlert = true;
        Physics2D.IgnoreLayerCollision(10, 9, false);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
}
