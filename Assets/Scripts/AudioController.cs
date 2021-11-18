using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audio;
    public static AudioController sharedInstance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (sharedInstance == null) sharedInstance = this;
    }
    void Start()

    {
        audio = GetComponent<AudioSource>();
        audio.mute = true;
    }

  
}
