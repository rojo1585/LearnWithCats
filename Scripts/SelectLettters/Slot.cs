using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int id;
    public char type;
    public bool empy;
    public bool  isCorrect;
    public Sprite letterIcon;
    public Transform slotLetterChield;
    //SlotAnswer slotAnswer;

    public int a;
    public bool isSelect;

    //public Trasform slotLetterChield;

    void Start(){
        slotLetterChield = this.transform.GetChild(0);
        
        empy = true;
        
    }

    public void UpdateSlot(Sprite spr){
        slotLetterChield.GetComponent<Image>().sprite = spr;
        letterIcon = spr;
    }
    public void UpdateCorrect(Sprite spr){
        slotLetterChield.GetComponent<Image>().sprite = spr;
        
    }


    public void Select(){
        this.isSelect = true;
    }
    
    public void RestOportunities(){
        if(!this.isCorrect){
            LetterCart.Instance.oportunities--;
            
        }
    }
}
