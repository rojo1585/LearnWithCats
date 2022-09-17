using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotAnswer : MonoBehaviour
{
    public bool empy;
    public char type;
    public Sprite icon;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void UpdateSlot(Sprite spr){
        this.GetComponent<Image>().sprite = spr;
    }

}
