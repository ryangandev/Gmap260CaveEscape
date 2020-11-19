using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class startTrigger : MonoBehaviour
{

    public static bool beginAlert = true;
    public TextMeshProUGUI notificationText;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            RisingLava.lavaRising = true;
            
            if(beginAlert)
            {
                StartCoroutine(sendNotification("*LAVA BEGINS TO RISE!*", 2));
            }
            beginAlert = false;
        }
    }

    IEnumerator sendNotification(string text, int time)
    {
        notificationText.text = text;
        yield return new WaitForSeconds(time);
        notificationText.text = "";
    }
}
