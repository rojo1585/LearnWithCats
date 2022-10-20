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

    private void Update() {
        if (score > 0 )
        {
            
        }
    }

    public void AddPointToScore(int cant){
        score += cant;
    }

    public void GetMedal(Texture2D[] list,GameObject panel,int score){

        if (score == list.Length )
        {
            panel.GetComponent<Image>().sprite = medalsSprite[0];
            

        }else if(score >= (list.Length / 3)){
            panel.GetComponent<Image>().sprite = medalsSprite[1];
        }else if(score >= (list.Length / 3)){
            panel.GetComponent<Image>().sprite = medalsSprite[2];
        }
    }

    public void ResetScore(){
        score=0;
    }

    public void ChngeTopic(){
        EceneManager.Instance.BackToSelectMenu();
            EceneManager.Instance.HidePanelWin();
            LetterCart.Instance.CleanPanels();
            ImagesController.Instance.CleanListNumRand();
            score = 0;
    }
}
