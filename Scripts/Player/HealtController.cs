using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtController : MonoBehaviour
{
    //[SerializeField] private List<Transform> positionHearts;
    [SerializeField] private GameObject[] heart;
    [SerializeField] private GameObject[] empyHeart;
    PlayerController playerController;

    void Start()
    {
        
        playerController = GetComponent<PlayerController>();
        
    }

    public void addHeart(){
        playerController.life++;
        heart[playerController.life].SetActive(true);
    }
    public void DestroyHeart(){
        heart[playerController.life].SetActive(false);
        playerController.life--;
    }


}
