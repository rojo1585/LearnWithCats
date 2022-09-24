using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EceneManager : MonoBehaviour
{
    [SerializeField] GameObject panelRestar;
    [SerializeField] GameObject panelWin;

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
        }
    }
    public void RestarLevel(){
        SceneManager.LoadScene("GameRunCat");
    }
}
