using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinContController : MonoBehaviour
{
    public float cont;
    [SerializeField]  Text contador;
    private bool enMarcha;
    public static CoinContController coinContController;
    private void Awake()
    {
        if (coinContController == null) coinContController = this;
        cont = 1;
        enMarcha = true;
    }
    void Update()
    {
        if (enMarcha)
        {
           contador.text = cont.ToString();
        }
    }
}
