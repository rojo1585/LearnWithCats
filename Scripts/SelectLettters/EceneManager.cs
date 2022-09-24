using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EceneManager : MonoBehaviour
{
    [SerializeField] GameObject PanelRestar;

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
    public void ShowPanelEndGame(){
        PanelRestar.SetActive(true);
    }
    public void RestarLevel(){
        SceneManager.LoadScene("GameRunCat");
    }
}
