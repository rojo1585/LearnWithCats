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
        icon = spr;
    }


    public void Select(){
        isSelect = true;
    }

}
