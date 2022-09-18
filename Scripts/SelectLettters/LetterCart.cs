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
    
    
    public GameObject[] letters;
    public GameObject[] slotList;
    public GameObject[] slotAnswerList;
    public GameObject slotLetters;
    [SerializeField] private GameObject answerPanel;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private Sprite correctSprite;

    

    public static LetterCart instance;
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
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            AddCorrectWord();
            AddLetterRandom();
            MakePanelsAnswer();
            //CheckAnswer();
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
                    item.GetComponent<SlotAnswer>().UpdateSlot(slotList[j].GetComponent<Slot>().icon);
                    slotList[j].transform.GetChild(0).gameObject.SetActive(false);
                    
                }
            }
        }
        
    }
}
