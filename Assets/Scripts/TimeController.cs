using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
  

    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;
    public static TimeController timeController;
    public float restante;
    private bool enMarcha;
   
    void Awake()
    {
        if (timeController == null) timeController = this;
        restante = (min * 60) + seg;
        enMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            restante -= Time.deltaTime;
            if (restante <= 0.5)
            {
                enMarcha = true;
                GameManager.sharedInstance.currentGameState = GameManager.GameState.gameOver;
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{1:00}", tempMin, tempSeg);

        }
    }

    public void disminucion (float a)
    {
        restante = restante - a;
    }
    public void aumento (float a)
    {
        restante = restante + a;
    }
    

}
