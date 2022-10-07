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
    [Header("ListsFood")]
    public Texture2D[] imagesFood;
    public string[] wordsFood;
    [Header("ListsAnimals")]
    public Texture2D[] imagesAnimals;
    public string[] wordsAnimals;
    public string selectWord;
    
    [SerializeField]private GameObject medalOne;
    [SerializeField]private GameObject medalTwo;
    [SerializeField]private GameObject medalThree;

    [SerializeField]private int numrRand;
    public char[] splitWordList;
    [SerializeField] private List<int> savedNumbers = new List<int>();
    public int selectList;
    private int a;
    [SerializeField] private int scoreOne;
    [SerializeField] private int scoreTwo;
    [SerializeField] private int scoreThree;
    
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
    
        if (selectList == 1)
        {   
            scoreOne = ScoreLetters.Instance.score;
            ScoreLetters.Instance.GetMedal(imagesHome, medalOne, scoreOne);
            medalOne.SetActive(true);
        }else if(selectList == 2){
            scoreTwo = ScoreLetters.Instance.score;
            ScoreLetters.Instance.GetMedal(imagesFood, medalTwo,scoreTwo);
            medalTwo.SetActive(true);
        }else if(selectList == 3){
            scoreThree = ScoreLetters.Instance.score;
            ScoreLetters.Instance.GetMedal(imagesAnimals, medalThree, scoreThree);
            medalThree.SetActive(true);
        }
    }

    public void SelectRandomImage(Texture2D[] images, string[] word){
        
        panelShowImage.GetComponent<RawImage>().texture = images[savedNumbers[a]];
        selectWord = word[savedNumbers[a]];
        a += 1;
    }


    public void SplitWord(){
        splitWordList = new char [selectWord.Length];
        for (int i = 0; i < selectWord.Length ; i++)
        {
            splitWordList[i] = selectWord[i];
        }
    }

    public void GenarateNumRand(Texture2D[] list ){
        while (savedNumbers.Count != list.Length){
            numrRand = Random.Range(0,list.Length);
            if(!savedNumbers.Contains(numrRand)){
                savedNumbers.Add(numrRand);
            }
        }
    }

    public void CleanListNumRand(){
        savedNumbers.Clear();
        a =0;
    }

    public void ChooseList(){
        if (selectList == 1)
        {   
            GenarateNumRand(imagesHome);               
            SelectRandomImage(imagesHome, wordsHome) ; 
            SplitWord(); 


            EceneManager.Instance.ShowPanel(3);
        }else if(selectList == 2){
            GenarateNumRand(imagesFood);  
            SelectRandomImage(imagesFood, wordsFood) ; 
            SplitWord(); 
            EceneManager.Instance.ShowPanel(3);
        }else if(selectList == 3){
            GenarateNumRand(imagesAnimals);  
            SelectRandomImage(imagesAnimals, wordsAnimals) ; 
            SplitWord();
            EceneManager.Instance.ShowPanel(3);
        }
    }




    
}
