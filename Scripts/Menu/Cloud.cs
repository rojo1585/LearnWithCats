using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private GameObject[] respawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToDestroy >= 47f){
            this.transform.position = respawns[Random.Range(0,4)].transform.position; 
            timeToDestroy = 0;
        }
        timeToDestroy += Time.deltaTime;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
