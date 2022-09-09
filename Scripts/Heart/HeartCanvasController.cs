using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCanvasController : MonoBehaviour
{
    

    public void DestroyHeart(){
        gameObject.SetActive(false);
    }

    public void AddHeart(){
        gameObject.SetActive(true);

    }
}
