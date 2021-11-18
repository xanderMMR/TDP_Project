using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;

    private void Awake()
    {
        optionsPanel.gameObject.SetActive(false);
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

    }
    public void QuitGame()
    {
        Application.Quit();  
    }
}
