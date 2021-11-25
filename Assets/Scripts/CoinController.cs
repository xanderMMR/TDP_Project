using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public AudioSource clip;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            AudioController.PlaySound("Coin_sound");
            Destroy(gameObject);
            CoinContController.coinContController.cont += 1;
        }
    }
}
