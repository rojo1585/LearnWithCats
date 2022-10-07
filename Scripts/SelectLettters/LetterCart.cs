using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCart : MonoBehaviour
{
    public GameObject  paneLetters;

    public int allSlot;
    public int allSlotAnswer;
    public int enableSlot;
    public int randNumer;

    [SerializeField] private List<int> savedNumbers = new List<int>();
    public int a;

    public bool stop;

    public int oportunities;
    public int countToWiner;
    
    
    
    public GameObject[] letters;
    public GameObject[] slotList;
    public GameObject[] slotAnswerList;

    public GameObject[] stars;
    public GameObject[] starsWinPanel;
    public GameObject slotLetters;
    [SerializeField] private GameObject answerPanel;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private GameObject starPanel;
    [SerializeField] private GameObject empyStarPanel;

    [SerializeField] private Sprite correctSprite;
    [SerializeField] private Sprite errorSprite;
    [SerializeField] private Sprite blockSprite;

    

    public static LetterCart instance;
    private bool ready;

    public static LetterCart Instance {get {return instance;}}

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        

        allSlot = slotLetters.transform.childCount;
        slotList = new GameObject[allSlot];
        
        for (int i = 0; i < allSlot; i++){
            slotList[i] = slotLetters.transform.GetChild(i).gameObject;
            slotList[i].GetComponent<Slot>().id = i;
        }
        
        countToWiner = 1;
        
    }

    void Update()
    {
        if (oportunities <= 0){
            EceneManager.Instance.ShowPanel(2);
            starPanel.SetActive(false);
            empyStarPanel.SetActive(false); 
        }
        if (countToWiner <= 0 && ready)
        {
            EceneManager.Instance.ShowPanel(1);
            starPanel.SetActive(false);
            empyStarPanel.SetActive(false);
            ready = false;
            ScoreLetters.Instance.AddPointToScore(1);
        }

        HidenStar();
        
        if (Input.GetButtonDown("Jump"))
        {
           // CleanPanels();
           AddCorrectWord();
        }
        
    }

    public void AddLetterRandom(){
        for (int i = 0; i < allSlot; i++)
        {
            randNumer = Random.Range(0,25);
            if (slotList[i].GetComponent<Slot>().empy)
            {
                slotList[i].GetComponent<Slot>().UpdateSlot(letters[randNumer].GetComponent<LettersItems>().icon); 
                slotList[i].GetComponent<Slot>().type = letters[randNumer].GetComponent<LettersItems>().type;
                slotList[i].GetComponent<Slot>().empy = false;
                
            }
        }
    }
    public int ab;

    public void AddCorrectWord(){


        ab = 0;
        savedNumbers.Clear();

        while (savedNumbers.Count != ImagesController.Instance.splitWordList.Length){
            ab = Random.Range(0,allSlot);
            if(!savedNumbers.Contains(ab)){
                savedNumbers.Add(ab);
            }
        }
        foreach (GameObject letter in letters)
        {
            for (int i = 0; i < ImagesController.Instance.splitWordList.Length ;i++)
            {
                if(letter.GetComponent<LettersItems>().TakeType() == ImagesController.Instance.splitWordList[i]){
                    if(!savedNumbers.Contains(ab)){}
                    slotList[savedNumbers[i]].GetComponent<Slot>().UpdateSlot(letter.GetComponent<LettersItems>().icon);
                    slotList[savedNumbers[i]].GetComponent<Slot>().type = letter.GetComponent<LettersItems>().TakeType();
                    slotList[savedNumbers[i]].GetComponent<Slot>().empy = false;
                    
                    
                }
            }
            
        }

/*
        for (int j = 0; j < ImagesController.Instance.splitWordList.Length; j++)
        {
            
            for (int i = 0; i < letters.Length;i++)
            {
                if(ImagesController.Instance.splitWordList[j] == letters[i].GetComponent<LettersItems>().type){
                    randNumer = Random.Range(1,allSlot);
                    slotList[randNumer].GetComponent<Slot>().UpdateSlot(letters[i].GetComponent<LettersItems>().icon);
                    slotList[randNumer].GetComponent<Slot>().type = letters[i].GetComponent<LettersItems>().type;
                    slotList[randNumer].GetComponent<Slot>().empy = false;
                    
                }
            }
        }
       
        foreach (char letter in ImagesController.Instance.selectWord)
        {
            for (int i = 0; i < letters.Length;i++)
            {
                if(letter == letters[i].GetComponent<LettersItems>().type){
                    randNumer = Random.Range(1,allSlot);
                    slotList[randNumer].GetComponent<Slot>().UpdateSlot(letters[i].GetComponent<LettersItems>().icon);
                    slotList[randNumer].GetComponent<Slot>().type = letters[i].GetComponent<LettersItems>().type;
                    slotList[randNumer].GetComponent<Slot>().empy = false;
                    
                }
            }
            
        }*/
    }


    public void MakePanelsAnswer(){
        

        for (int i = 0; i < ImagesController.Instance.selectWord.Length; i++)
        {
            GameObject panel  = Instantiate(panelPrefab);
            panel.transform.SetParent(answerPanel.transform);
        }

        allSlotAnswer = answerPanel.transform.childCount;
        slotAnswerList = new GameObject[allSlotAnswer];
        countToWiner = allSlotAnswer;
        for (int i = 0; i < allSlotAnswer; i++){
            slotAnswerList[i] = answerPanel.transform.GetChild(i).gameObject;
            slotAnswerList[i].GetComponent<SlotAnswer>().type = ImagesController.Instance.splitWordList[i];
        }
        //panel.transform.scale = new Vector3(1,1,0);
    }

    public void CheckAnswer(){
        
        foreach (GameObject item in slotAnswerList)
        {
            for (int j = 0; j < allSlot ; j++){
                

                if (slotList[j].GetComponent<Slot>().isSelect && item.GetComponent<SlotAnswer>().type == slotList[j].GetComponent<Slot>().type )
                {
                    item.GetComponent<SlotAnswer>().UpdateSlotAnswer(slotList[j].GetComponent<Slot>().letterIcon);
                    item.GetComponent<SlotAnswer>().empy = false;
                    item.GetComponent<SlotAnswer>().type = slotList[j].GetComponent<Slot>().type;
                    slotList[j].GetComponent<Slot>().UpdateCorrect(correctSprite);
                    slotList[j].GetComponent<Slot>().isCorrect = true;
                    //slotList[j].transform.GetChild(0).gameObject.SetActive(false);
                }else if(!slotList[j].GetComponent<Slot>().isCorrect && slotList[j].GetComponent<Slot>().isSelect && item.GetComponent<SlotAnswer>().type != slotList[j].GetComponent<Slot>().type ){
                    slotList[j].GetComponent<Slot>().UpdateCorrect(errorSprite);
                    
                    
                }
            }
                
        }
        
    }

    public void CheckWiner()
    {   
    
        countToWiner = allSlotAnswer;
        foreach (GameObject item in slotAnswerList)
        {
            if(!item.GetComponent<SlotAnswer>().empy && ready){
                countToWiner--;
                
            }
        }
    }


    public void ShowLetters(){
            AddCorrectWord();
            AddLetterRandom();
            MakePanelsAnswer();
            ready = true;
    }

    public void HidenStar(){
        if(oportunities == 2){
            stars[0].SetActive(false);
            starsWinPanel[0].SetActive(false);
        }
        if(oportunities == 1){
            stars[1].SetActive(false);
            starsWinPanel[1].SetActive(false);
        }
        if(oportunities == 0){
            stars[2].SetActive(false);
            starsWinPanel[2].SetActive(false);
            } 
    }

    public void RestarStarts(){
        stars[0].SetActive(true);
        stars[1].SetActive(true);
        stars[2].SetActive(true);
        starsWinPanel[0].SetActive(true);
        starsWinPanel[1].SetActive(true);
        starsWinPanel[2].SetActive(true);
        starPanel.SetActive(true);
        empyStarPanel.SetActive(true);
        oportunities = 3;
        
    }

    public void CleanPanels(){
        
        for (int i = 0; i < allSlot; i++)
        {
            
            if (!slotList[i].GetComponent<Slot>().empy)
            {
                slotList[i].GetComponent<Slot>().UpdateSlot(blockSprite); 
                slotList[i].GetComponent<Slot>().type = ' ';
                slotList[i].GetComponent<Slot>().empy = true;
                slotList[i].GetComponent<Slot>().isCorrect = false;
                slotList[i].GetComponent<Slot>().isSelect = false;
            }
        }

        for (int i = 0; i < allSlotAnswer; i++){
            Destroy(slotAnswerList[i].gameObject);
        }
    }


}
