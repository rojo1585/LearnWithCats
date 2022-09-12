using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject gameSelectPanel;


    public void ChangePanel(GameObject panel){
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        gameSelectPanel.SetActive(false);
        panel.SetActive(true);
    }

    
    public void StarGame(string nameScene){
        SceneManager.LoadScene(nameScene);
    }


}
