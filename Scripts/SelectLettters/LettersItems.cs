using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersItems : MonoBehaviour
{
    public int id;
    public char type;
    public Sprite icon;

    public bool selectLetter;

    void Start(){
        icon = this.GetComponent<Image>().sprite;
    }
}
