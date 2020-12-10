using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip axeSwingSound, rockHitSound, hurtSound, coinSound, loseSound, winSound, lavaSound;
    static AudioSource audioSrc;    

    // Start is called before the first frame update
    void Start()
    {
        axeSwingSound = Resources.Load<AudioClip>("Swing");
        rockHitSound = Resources.Load<AudioClip>("Hit");
        hurtSound = Resources.Load<AudioClip>("hurt");
        coinSound = Resources.Load<AudioClip>("coin");
        loseSound = Resources.Load<AudioClip>("lose");
        winSound = Resources.Load<AudioClip>("win");
        lavaSound = Resources.Load<AudioClip>("lava");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch(clip){
            case "swing":
                audioSrc.PlayOneShot(axeSwingSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(rockHitSound);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurtSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "lose":
                audioSrc.PlayOneShot(loseSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            case "lava":
                audioSrc.PlayOneShot(lavaSound);
                break;
        }
    }
}
