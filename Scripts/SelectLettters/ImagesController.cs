using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesController : MonoBehaviour
{   
    [SerializeField] private GameObject panelShowImage;
    [Header("ListsHome")]
    public Texture2D[] imagesHome;
    public string[] wordsHome;
    [Header("ListsSchool")]
    public Texture2D[] imagesSchool;
    public string[] wordsSchool;
    [Header("ListsAnimals")]
    public Texture2D[] imagesAnimals;
    public string[] wordsAnimals;
    public string selectWord;
    
    [SerializeField]private int numrRand;
    public char[] splitWordList;

    public int selectList;
    
    public static ImagesController instance;
    public static ImagesController Instance {get {return instance;}}

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
            
        }
        

    }
    
    private void Start() {
        //SelectRandomImage(imagesHome, wordsHome) ; 
        //SplitWord();
    }
    private void Update() {
        
        
    }

    public void SelectRandomImage(Texture2D[] images, string[] word){
        numrRand =  Random.Range(0,images.Length);
        panelShowImage.GetComponent<RawImage>().texture = images[numrRand];
        selectWord = word[numrRand];
        
    }


    public void SplitWord(){
        splitWordList = new char [selectWord.Length];
        for (int i = 0; i < selectWord.Length ; i++)
        {
            splitWordList[i] = selectWord[i];
        }
    }

    public void ChooseList(){
        if (selectList == 1)
        {                  
            SelectRandomImage(imagesHome, wordsHome) ; 
            SplitWord(); 
            EceneManager.Instance.ShowPanel(3);
        }else if(selectList == 2){
            SelectRandomImage(imagesSchool, wordsSchool) ; 
            SplitWord(); 
            EceneManager.Instance.ShowPanel(3);
        }else if(selectList == 3){
            SelectRandomImage(imagesAnimals, wordsAnimals) ; 
            SplitWord();
            EceneManager.Instance.ShowPanel(3);
        }
    }

   



    
}
