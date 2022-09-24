using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotAnswer : MonoBehaviour
{
    public bool empy;
    public char type;
    public Sprite icon;

    private void Start() {
        empy = true;
    }
    public void UpdateSlotAnswer(Sprite spr){
        this.GetComponent<Image>().sprite = spr;
    }
    
    public void isEmpy(){
        if(!this.empy){
            LetterCart.Instance.countToWiner--;
        }
    }



}
