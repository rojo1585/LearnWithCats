using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesController : MonoBehaviour
{   
    [SerializeField] private GameObject panelShowImage;
    public Texture2D[] images;
    public string[] words;
    public string selectWord;
    private int numrRand;
    public char[] splitWordList;
    
    public static ImagesController instance;
    public static ImagesController Instance {get {return instance;}}

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }

        
    }
    
    private void Start() {
        SelectRandomImage() ; 
        SplitWord();
    }
    private void Update() {
        if (Input.GetButtonDown("Jump"))
        {                   
        }
    }

    public void SelectRandomImage(){
        numrRand =  Random.Range(0,4);
        panelShowImage.GetComponent<RawImage>().texture = images[numrRand];
        selectWord = words[numrRand];
        
    }


    public void SplitWord(){
        splitWordList = new char [selectWord.Length];
        for (int i = 0; i < selectWord.Length ; i++)
        {
            splitWordList[i] = selectWord[i];
        }
    }


    
}
