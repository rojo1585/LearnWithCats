using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topics : MonoBehaviour
{
    [SerializeField] private int id;

    public void GetId(){
        ImagesController.Instance.selectList = this.id;
    } 
}
