using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioSource au;
    public static AudioController sharedInstance;
    // Start is called before the first frame update
    public static AudioClip coinPickUp;

    private void Start()
    {
        coinPickUp = Resources.Load<AudioClip>("Coin_sound");
        au = GetComponent<AudioSource>();
        au.mute = true;
    }
    private void Awake()
    {
        if (sharedInstance == null) sharedInstance = this;
    }
    public static void PlaySound(string clip)
    {
        switch (clip) { 
            case "Coin_sound":
                au.PlayOneShot(coinPickUp);
                break;
        
                    }
    }


}
