using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EceneManager : MonoBehaviour
{
    [SerializeField] GameObject panelRestar;
    [SerializeField] GameObject panelWin;
    [SerializeField] GameObject panelSelectTopic;
    [SerializeField] GameObject panelMain;

    private static EceneManager instance;
    public static EceneManager Instance {get {return instance;}}

    private void Awake() {
        if (instance == null)
        {   
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    public void ShowPanel(int panel){
        if(panel == 1){
            panelWin.SetActive(true);
        }else if(panel == 2){
            panelRestar.SetActive(true);
        }else if(panel == 3){
            panelSelectTopic.SetActive(false);
            panelMain.SetActive(true);
        }
    }
    public void RestarLevel(){
        SceneManager.LoadScene("GameRunCat");
    }

    public void NextQuest(){
        panelWin.SetActive(false);
        ImagesController.Instance.ChooseList();
    }

    public void BackToSelectMenu(){
        panelMain.SetActive(false);
        panelSelectTopic.SetActive(true);
    }

    public void HidePanelWin(){
        panelWin.SetActive(false);
    }
}
