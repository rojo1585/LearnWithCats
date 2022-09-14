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
            AddLetter();
        }
    }

    public void AddLetter(){
        for (int i = 0; i < allSlot; i++)
        {
            randNumer = Random.Range(0,25);
            if (slotList[i].GetComponent<Slot>().empy)
            {
                slotList[i].GetComponent<Slot>().UpdateSlot(letters[randNumer].GetComponent<LettersItems>().icon); 
            }
        }
    }
}
