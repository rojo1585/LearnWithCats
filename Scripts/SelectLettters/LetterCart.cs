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
    
    
    public GameObject[] letters;
    [SerializeField]private GameObject[] slotList;
    [SerializeField] private GameObject[] slotAnswerList;
    public GameObject slotLetters;
    [SerializeField] private GameObject answerPanel;
    [SerializeField] private GameObject panelPrefab;

    void Start()
    {
        
        allSlot = slotLetters.transform.childCount;
        slotList = new GameObject[allSlot];
        
        for (int i = 0; i < allSlot; i++){
            slotList[i] = slotLetters.transform.GetChild(i).gameObject;
        }
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            AddCorrectWord();
            //AddLetterRandom();
            //MakePanelsAnswer();
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
        }
        //panel.transform.scale = new Vector3(1,1,0);
    }

    public void CheckAnswer(){
        for (int i = 0; i < allSlotAnswer; i++){
            slotAnswerList[i] = answerPanel.transform.GetChild(i).gameObject;
        }
    }
}
