using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCart : MonoBehaviour
{
    public GameObject  paneLetters;

    public int allSlot;
    public int enableSlot;
    public int randNumer;
    public int a;
    
    
    public GameObject[] letters;
    [SerializeField]private GameObject[] slotList;
    public GameObject slotLetters;

    void Start()
    {
        allSlot = slotLetters.transform.childCount;
        slotList = new GameObject[allSlot];
        for (int i = 0; i < allSlot; i++){
            slotList[i] = slotLetters.transform.GetChild(i).gameObject;
            if (slotList[i].GetComponent<Slot>().empy)
            {
                
            }
        }
        

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            AddW();
            AddLetterRandom();
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

    /*public void AddCorrectWord(){
        for (int i = 0; i < ImagesController.Instance.selectWord.Length; i++)
        {
            randNumer = Random.Range(0,20);
            for (int j = 0; j < allSlot; j++)
            {     
                if (slotList[j].GetComponent<Slot>().empy && letters[j].GetComponent<LettersItems>().type == ImagesController.Instance.selectWord[a])
                {   
                    if (a <ImagesController.Instance.selectWord.Length )
                    {
                        a++;  
                        slotList[randNumer].GetComponent<Slot>().UpdateSlot(letters[j].GetComponent<LettersItems>().icon);          
                        slotList[randNumer].GetComponent<Slot>().empy = true;
                    }                        
                }   
            }
            
        }
    }*/

    public void AddW(){
        foreach (char letter in ImagesController.Instance.selectWord)
        {
            
            for (int i = 0; i < allSlot; i++)
            {
                if(letter == letters[i].GetComponent<LettersItems>().type){
                    randNumer = Random.Range(1,20);
                    slotList[randNumer].GetComponent<Slot>().UpdateSlot(letters[i].GetComponent<LettersItems>().icon);
                    slotList[randNumer].GetComponent<Slot>().empy = false;
                }
            }
            
        }
    }
}
