using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject playButton;
    public GameObject optionsPanel;
    public GameObject gameSelectPanel;


    public void ChangePanel(GameObject panel){
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        gameSelectPanel.SetActive(false);
        playButton.SetActive(false);
        panel.SetActive(true);
    }

    public void ActiveButton(){
        playButton.SetActive(true);
    }

    
    public void StarGame(string nameScene){
        SceneManager.LoadScene(nameScene);
    }


}
