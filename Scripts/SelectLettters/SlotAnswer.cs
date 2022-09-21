using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotAnswer : MonoBehaviour
{
    public bool empy;
    public char type;
    public Sprite icon;

    public void UpdateSlotAnswer(Sprite spr){
        this.GetComponent<Image>().sprite = spr;
    }



}
