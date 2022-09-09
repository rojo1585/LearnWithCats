using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabHeart;
    [SerializeField] private GameObject prefabEmpyHeart;
    private int poolSize;
    [SerializeField] private List<GameObject> heartList;
    [SerializeField] private List<GameObject> empyHeartList;

    private static HeartPool instance;
    public static HeartPool Instance { get {return instance;}}
    private void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        poolSize = 3;
        AddHeartToPool(poolSize);
        RequesHeart();
        //AddEmpyHeartToPool(poolSize);
        
    }

    
    private void  AddHeartToPool(int amount){
        for(int i = 0; i < poolSize; i++){
            GameObject heart = Instantiate(prefabHeart);
            heart.SetActive(false);
            heartList.Add(heart);
            heart.transform.SetParent(transform);
        }
    }

    public GameObject RequesHeart(){
        for(int i = 0; i < heartList.Count; i++){
            if(!heartList[i].activeSelf){
                heartList[i].SetActive(true);
                return heartList[i];
            }
        }
        AddHeartToPool(1);
        heartList[heartList.Count -1].SetActive(true);
        return heartList[heartList.Count - 1];
    }


    //----------------Empy Heart Methods--------------------------------//
    /*private void  AddEmpyHeartToPool(int amount){
        for(int i = 0; i < poolSize; i++){
            GameObject empyHeart = Instantiate(prefabEmpyHeart);
            empyHeart.SetActive(false);
            empyHeartList.Add(empyHeart);
            empyHeart.transform.SetParent(transform);
        }
    }

    public GameObject RequesEmpyHeart(){
        for(int i = 0; i < empyHeartList.Count; i++){
            if(!empyHeartList[i].activeSelf){
                empyHeartList[i].SetActive(true);
                return empyHeartList[i];
            }
        }
        AddHeartToPool(1);
        empyHeartList[heartList.Count -1].SetActive(true);
        return empyHeartList[empyHeartList.Count - 1];
    }
*/
}
