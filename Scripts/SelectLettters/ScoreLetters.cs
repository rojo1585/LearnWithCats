using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLetters : MonoBehaviour
{

    public int score;

    

    [SerializeField] private Sprite[] medalsSprite;

    public static ScoreLetters instance;
    public static ScoreLetters Instance {get {return instance;}}
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }else{Destroy(gameObject);}
    }

    public void AddPointToScore(int cant){
        score += cant;
    }

    public void GetMedal(Texture2D[] list,GameObject panel){

        if (score == list.Length )
        {
            panel.GetComponent<Image>().sprite = medalsSprite[0];
            EceneManager.Instance.BackToSelectMenu();
            EceneManager.Instance.HidePanelWin();

        }else if(score <= (list.Length / 2) && score >= (list.Length / 3)){
            panel.GetComponent<Image>().sprite = medalsSprite[1];
        }else if(score <= (list.Length / 3)){
            panel.GetComponent<Image>().sprite = medalsSprite[2];
        }
    }
}
