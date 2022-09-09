using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtController : MonoBehaviour
{
    //[SerializeField] private List<Transform> positionHearts;
    [SerializeField] private List<GameObject> pointToSpawn;
    //[SerializeField] private Transform[] p;
    //[SerializeField] private GameObject[] heartList;
    
    //[SerializeField] private GameObject[] empyHeart;
    

    void Start()
    {     
        InitalSpawnHeart();
        //InitalSpawnEmpyHeart();
    }

    private void InitalSpawnHeart(){

            for ( int i = 0; i < pointToSpawn.Count ; i++)
            {
                GameObject heart = HeartPool.Instance.RequesHeart();
                heart.transform.position = pointToSpawn[i].transform.position;

                GameObject empyHeart = HeartPool.Instance.RequesEmpyHeart();
                empyHeart.transform.position = pointToSpawn[i].transform.position;
            }
            /*
            GameObject heartOne = HeartPool.Instance.RequesHeart();
            heartOne.transform.position = pointToSpawn[0].transform.position;

            GameObject heartTwo = HeartPool.Instance.RequesHeart();
            heartTwo.transform.position = pointToSpawn[1].transform.position;

            GameObject heartTree = HeartPool.Instance.RequesHeart();
            heartTree.transform.position = pointToSpawn[2].transform.position;*/
    }
    /*
    private void InitalSpawnEmpyHeart(){
            for (int i = 0; i < pointToSpawn.Count; i++)
            {
                GameObject empyHeart = HeartPool.Instance.RequesEmpyHeart();
                empyHeart.transform.position = pointToSpawn[i].transform.position;
                
                //empyHeart.SetActive(false);
            }
        
        
    }*/


/*
    public void AddHeart(){
        
        playerController.life++;
        heart[playerController.life].SetActive(true);
    }
    public void DestroyHeart(){
        heart[playerController.life].SetActive(false);
        AddEmpyHeart();
        playerController.life--;
    }

    public void AddEmpyHeart(){
        empyHeart[playerController.life].SetActive(true);
    }

    public void DrestroyEmpyHeart(){
        empyHeart[playerController.life].SetActive(false);
    }
*/

}
