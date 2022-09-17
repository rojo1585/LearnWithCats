using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int id;
    public char type;
    public bool empy;
    public Sprite icon;
    public Transform slotLetterChield;
    SlotAnswer slotAnswer;

    public int a;
    public bool isSelect;

    //public Trasform slotLetterChield;

    void Start(){
        slotLetterChield = this.transform.GetChild(0);
        
        empy = true;
        
    }

    public void UpdateSlot(Sprite spr){
        slotLetterChield.GetComponent<Image>().sprite = spr;
        icon = slotLetterChield.GetComponent<Image>().sprite;
    }

    public void CheckAnswer(){
        foreach (GameObject item in LetterCart.Instance.slotAnswerList)
        {
            if(this.type == item.AddComponent<SlotAnswer>().type){
                item.GetComponent<SlotAnswer>().UpdateSlot(this.icon);
            }else{isSelect = true;}            
        }
    }

    public void Select(){
        isSelect = true;
    }

}
