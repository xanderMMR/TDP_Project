using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject nextLevel;
    public static UIManager sharedInstance;
    private void Awake()
    {
        if (sharedInstance == null) sharedInstance = this;
        optionsPanel.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(false);
    }
    public void OptionPanel()
    {
        GameManager.sharedInstance.currentGameState = GameManager.GameState.menu;
        optionsPanel.SetActive(true);
    }
    public void Return()
    {
        GameManager.sharedInstance.currentGameState = GameManager.GameState.inGame;
        optionsPanel.SetActive(false);
    }
    public void AnotherOption()
    {

    }
    public void GoMainMenu()
    {
        //TODO Menu principal
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NextLevelUI()
    {
        nextLevel.SetActive(true);
        GameManager.sharedInstance.currentGameState = GameManager.GameState.menu;

    }
    public void NextLevel()
    {
        if (Application.loadedLevelName == "Level_1") SceneManager.LoadScene("Level_2", LoadSceneMode.Single);
        else if (Application.loadedLevelName == "Level_2") SceneManager.LoadScene("Level_3", LoadSceneMode.Single);
        else if (Application.loadedLevelName == "Level_3") SceneManager.LoadScene("Level_4", LoadSceneMode.Single);
        else if (Application.loadedLevelName == "Level_4") SceneManager.LoadScene("Level_5", LoadSceneMode.Single);
        else if (Application.loadedLevelName == "Level_5") SceneManager.LoadScene("Level_6", LoadSceneMode.Single);
        else if (Application.loadedLevelName == "Level_6") SceneManager.LoadScene("Level_7", LoadSceneMode.Single);
        else if (Application.loadedLevelName == "Level_7") SceneManager.LoadScene("Level_8", LoadSceneMode.Single);
        //print("Colision - Gano el juego");
    }
   
}
