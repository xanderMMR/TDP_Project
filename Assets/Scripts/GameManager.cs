using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   //Poner los estados del juego

    public enum GameState
    {
        menu,
        inGame,
        gameOver
    }
    // Start is called before the first frame update

    //Inicializamos el enum
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;

    private void Awake()
    {   
        if (sharedInstance ==null) sharedInstance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (currentGameState == GameState.inGame)
        {
            Time.timeScale = 1f;
        }
        else if (currentGameState == GameState.menu)  {
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            BackToMenu(); 
        }

    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }
    //
    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //TODO
        }
        else if (newGameState == GameState.inGame)
        {

        } 
        else if (newGameState == GameState.gameOver)
        {

        }
        this.currentGameState = newGameState;
    }
}
