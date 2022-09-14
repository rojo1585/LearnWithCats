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

    private void Update() {
        if (Input.GetButtonDown("Jump"))
        {
            SelectRandomImage() ;           
        }
    }

    public void SelectRandomImage(){
        numrRand =  Random.Range(0,4);
        panelShowImage.GetComponent<RawImage>().texture = images[numrRand];
        selectWord = words[numrRand];

    }


    
}
