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
    public string a;

    public bool stop;

    public int oportunities;
    public int countToWiner;
    
    
    
    public GameObject[] letters;
    public GameObject[] slotList;
    public GameObject[] slotAnswerList;
    public GameObject slotLetters;
    [SerializeField] private GameObject answerPanel;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private Sprite correctSprite;
    [SerializeField] private Sprite errorSprite;

    

    public static LetterCart instance;
    private bool init;

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
        init = false;
        countToWiner = 1;
        
    }

    void Update()
    {
        if (oportunities <= 0){
            EceneManager.Instance.ShowPanel(2);
        }
        if (countToWiner <= 0)
        {
            EceneManager.Instance.ShowPanel(1);
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


    public void AddCorrectWord(){
        foreach (char letter in ImagesController.Instance.splitWordList)
        {
            a = a + letter;
            for (int i = 0; i < letters.Length;i++)
            {
                if(letter == letters[i].GetComponent<LettersItems>().type){
                    randNumer = Random.Range(1,19);
                    slotList[randNumer].GetComponent<Slot>().UpdateSlot(letters[i].GetComponent<LettersItems>().icon);
                    slotList[randNumer].GetComponent<Slot>().type = letters[i].GetComponent<LettersItems>().type;
                    slotList[randNumer].GetComponent<Slot>().empy = false;
                    
                }
            }
            
        }
    }


    private void MakePanelsAnswer(){
        

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
                }else if(slotList[j].GetComponent<Slot>().isCorrect == false && slotList[j].GetComponent<Slot>().isSelect ){
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
            if(!item.GetComponent<SlotAnswer>().empy){
            countToWiner--;
            }
        }
        
        
        
    }


    public void ShowLetters(){
            AddCorrectWord();
            AddLetterRandom();
            MakePanelsAnswer();
            init = true;
    }

}
