using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImpactController : MonoBehaviour
{
    public AudioSource clip;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play(); 
        }
    }
}
