using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    
    public int id;
    public bool empy;
    public Sprite icon;
    public Transform slotLetterChield;

    //public Trasform slotLetterChield;
    
    void Start(){
        slotLetterChield = this.transform.GetChild(0);
        empy = true;
        
    }

    public void UpdateSlot(Sprite spr){
        slotLetterChield.GetComponent<Image>().sprite = spr;
    }

   
}
